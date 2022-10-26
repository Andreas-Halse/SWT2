

using SWT2;

namespace ClassLibrary
{
    public class StationControl
    {
        // Enum med tilstande ("states") svarende til tilstandsdiagrammet for klassen
        public enum LadeskabState
        {
            Available,
            Locked,
            DoorOpen
        };

        // Her mangler flere member variable
        private LadeskabState _state;
        private IChargeControl _charger;
        private int _oldId;
        private IDoor _door;
        private IDisplay _display;
        private RFIDReader _RFIDReader;

        private ILogFile _logFile;

        public StationControl(IChargeControl charger, IDoor door, IDisplay display, RFIDReader rfidReader, ILogFile logfile )
     
        {
            _RFIDReader = rfidReader;
            _logFile = logfile;
            _charger = charger;
            _door = door;
            _display = display;
            _state = LadeskabState.Available;
            _door.DoorStateChange += OnDoorStateChange;
            _RFIDReader.RFIDDetected += OnRFIDDetected;

        }

        public void OnDoorStateChange(object? door, DoorEventArgs doorArgs)
        {
            if (doorArgs.open)
            {
                //hvis door er open
                _display.LoadRFID();
                _state = LadeskabState.DoorOpen;
            }
            else
            {
                //hvis door er closed
                _display.Connection();
                _state = LadeskabState.Available;
            }
        }

        public void OnRFIDDetected(object? rfidReader, RFIDDetectedEventArgs rfidArgs)
        {
            
            //Hvis ladeskabet ikke er optaget
            if (_state == LadeskabState.Available)
            {
                //Check om telefonen er tilkoblet
                if (!_charger.IsConnected())
                {
                    return;
                }
                
                //Laas/brug skabet
                _charger.StartCharge();

                _door.DoorLock();
                _oldId = rfidArgs.id;

                _logFile.LogDoorLocked(_oldId);

                _state = LadeskabState.Locked;
            }
            // Hvis ladeskabet allerede er i brug
            else if(_state ==LadeskabState.Locked)
            {
                //verificer det er den korrekte bruger og så frigiv telefon/skab
                if (checkId(rfidArgs.id))
                {
                    _charger.StopCharge();
                    _door.DoorUnlock();
                    _logFile.LogDoorUnlocked(rfidArgs.id);
                    _state = LadeskabState.Available;
                    _display.RemovePhone();
                }
            }
            
        }

        private bool checkId(int id)
        {
            if (id == _oldId)
            {
                
                return true;
            }
            else
            {
                //Hvis forkert id
                _display.RFIDError();
                return false;
            }
        }
        
    }
}
