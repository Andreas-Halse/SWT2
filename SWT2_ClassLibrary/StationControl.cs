

using SWT2;

namespace ClassLibrary
{
    public interface IStationControl
    {
        StationControl.LadeskabState _state { get; set; }
        void OnDoorStateChange(object? door, DoorEventArgs doorArgs);
        void OnRFIDDetected(object? rfidReader, RFIDEventArgs rfidArgs);
        int _oldId { get; }

    }

    public class StationControl : IStationControl
    {
        // Enum med tilstande ("states") svarende til tilstandsdiagrammet for klassen
        public enum LadeskabState
        {
            Available,
            Locked,
            DoorOpen
        };

        // Her mangler flere member variable
        public LadeskabState _state { get; set; }
        private IChargeControl _charger;
        public  int _oldId { get; private set; }
        private IDoor _door;
        private IDisplay _display;
        private IRFIDReader _RFIDReader;

        private ILogFile _logFile;

        public StationControl(IChargeControl charger, IDoor door, IDisplay display, IRFIDReader rfidReader, ILogFile logfile )
     
        {
            _RFIDReader = rfidReader;
            _logFile = logfile;
            _charger = charger;
            _door = door;
            _display = display;
            _state = LadeskabState.Available;
            _door.DoorStateChange += OnDoorStateChange;
            _RFIDReader.RfidDetected += OnRFIDDetected;

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

        public void OnRFIDDetected(object? rfidReader, RFIDEventArgs rfidArgs)
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

                _logFile.logDoorLocked(_oldId);

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
                    _logFile.logDoorUnlocked(rfidArgs.id);
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
