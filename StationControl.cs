

using SWT2;

namespace ClassLibrary
{
    public class StationControl
    {
        // Enum med tilstande ("states") svarende til tilstandsdiagrammet for klassen
        private enum LadeskabState
        {
            Available,
            Locked,
            DoorOpen
        };

        // Her mangler flere member variable
        private LadeskabState _state;
        private IUsbCharger _charger;
        private int _oldId;
        private IDoor _door;
        private IDisplay _display;
        private RFIDReader _RFIDReader;

        private ILogFile _logFile;

        // Her mangler constructor
        StationControl(IUsbCharger charger, IDoor door, IDisplay display, RFIDReader rfidReader, ILogFile logfile )
     
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
            if (doorArgs.locked)
            {
                _display.LoadRFID();
                _state= LadeskabState.Available;
            }
            else
            {
                _display.Connection();
                _state = LadeskabState.DoorOpen;
            }
        }

        public void OnRFIDDetected(object? rfidReader, RFIDDetectedEventArgs rfidArgs)
        {
            
            
            if (_state == LadeskabState.Available)
            {
                if (!_charger.Connected)
                {
                    _display.ConnectionError();
                    return;
                }
                _charger.StartCharge();

                _door.DoorLock();
                _oldId = rfidArgs.id;

                _logFile.LogDoorLocked(_oldId);

                _state = LadeskabState.Locked;
            }
            else if(_state ==LadeskabState.Locked)
            {
                if (checkId(rfidArgs.id))
                {
                    _charger.StopCharge();
                    _door.DoorUnlock();
                    _logFile.LogDoorUnlocked(rfidArgs.id);
                    _state = LadeskabState.Available;
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
                _display.RFIDError();
                return false;
            }
        }

        /*
        // Eksempel på event handler for eventet "RFID Detected" fra tilstandsdiagrammet for klassen
        private void RfidDetected(int id)
        {
            switch (_state)
            {
                case LadeskabState.Available:
                    // Check for ladeforbindelse
                    if (_charger.Connected)
                    {
                        _door.LockDoor();
                        _charger.StartCharge();
                        _oldId = id;
                        using (var writer = File.AppendText(logFile))
                        {
                            writer.WriteLine(DateTime.Now + ": Skab låst med RFID: {0}", id);
                        }

                        Console.WriteLine("Skabet er låst og din telefon lades. Brug dit RFID tag til at låse op.");
                        _state = LadeskabState.Locked;
                    }
                    else
                    {
                        Console.WriteLine("Din telefon er ikke ordentlig tilsluttet. Prøv igen.");
                    }

                    break;

                case LadeskabState.DoorOpen:
                    // Ignore
                    break;

                case LadeskabState.Locked:
                    // Check for correct ID
                    if (id == _oldId)
                    {
                        _charger.StopCharge();
                        _door.UnlockDoor();
                        using (var writer = File.AppendText(logFile))
                        {
                            writer.WriteLine(DateTime.Now + ": Skab låst op med RFID: {0}", id);
                        }

                        Console.WriteLine("Tag din telefon ud af skabet og luk døren");
                        _state = LadeskabState.Available;
                    }
                    else
                    {
                        Console.WriteLine("Forkert RFID tag");
                    }

                    break;
            }
        }
        */
        // Her mangler de andre trigger handlere
    }
}
