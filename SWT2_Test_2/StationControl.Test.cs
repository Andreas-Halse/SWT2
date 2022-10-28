using System;
using System.IO;
using ClassLibrary;
using NSubstitute;
using NUnit.Framework;
using SWT2;

namespace SWT2_Test
{



    [TestFixture]
    public class StationControl_Test
    {
        private IStationControl _uut;
        private IDoor _door;
        private IRFIDReader _rfidReader;
        private IDisplay _display;
        private ILogFile _logFile;
        private IChargeControl _chargeControl;
        [SetUp]
        public void Setup()
        {
            _door = Substitute.For<IDoor>();
            _rfidReader = Substitute.For<IRFIDReader>();
            _display = Substitute.For<IDisplay>();
            _logFile = Substitute.For<ILogFile>();
            _chargeControl = Substitute.For<IChargeControl>();
            _uut = new StationControl(_chargeControl, _door, _display, _rfidReader, _logFile);
        }

        [Test]
        public void OnDoorStateChange_Open()
        {
            _door.DoorStateChange += Raise.EventWith(new DoorEventArgs() { open = true });
            _display.Received(1).Connection();
            Assert.That(_uut._state, Is.EqualTo(StationControl.LadeskabState.DoorOpen));
        }


        [Test]
        public void OnDoorStateChange_Closed()
        {
            _door.DoorStateChange += Raise.EventWith(new DoorEventArgs() { open = false });
            _display.Received(1).Connection();
            Assert.That(_uut._state, Is.EqualTo(StationControl.LadeskabState.Available));
        }

        [Test]
        public void OnRFIDDetected_Available() //tester RFID hele eventhandleren hvis _state er avalible ved entry
        //lidt lang test. Man kunne overveje at dele den op i 2.
        {
            _uut._state = StationControl.LadeskabState.Available;
            _chargeControl.IsConnected().Returns(false);
            _rfidReader.RfidDetected += Raise.EventWith(new RFIDEventArgs() { id = 1 });
            _chargeControl.Received(0).StartCharge();
            _door.Received(0).DoorLock();
            _logFile.Received(0).logDoorLocked(1);

            Assert.That(_uut._state, Is.EqualTo(StationControl.LadeskabState.Available));
            _chargeControl.IsConnected().Returns(true);

            _rfidReader.RfidDetected += Raise.EventWith(new RFIDEventArgs() { id = 1 });
            _chargeControl.Received(1).StartCharge();
            _door.Received(1).DoorLock();
            _logFile.Received(1).logDoorLocked(1);
            Assert.That(_uut._state, Is.EqualTo(StationControl.LadeskabState.Locked));
        }

        [Test]
        public void OnRFIDDetected_Locked() //Tester Rfid eventhandler hvis entry state er locked
        {
            _uut._state = StationControl.LadeskabState.Available;
            _chargeControl.IsConnected().Returns(true);
            _rfidReader.RfidDetected += Raise.EventWith(new RFIDEventArgs() { id = 2 });

            //nu er den locked med oldID = 2
            Assert.That(_uut._state, Is.EqualTo(StationControl.LadeskabState.Locked));
            Assert.That(_uut._oldId, Is.EqualTo(2));


            _rfidReader.RfidDetected += Raise.EventWith(new RFIDEventArgs() { id = 1 });
            _chargeControl.Received(0).StopCharge();
            _display.Received(1).RFIDError();
            Assert.That(_uut._state, Is.EqualTo(StationControl.LadeskabState.Locked));


            _rfidReader.RfidDetected += Raise.EventWith(new RFIDEventArgs() { id = 2 });
            _chargeControl.Received(1).StopCharge();
            _door.Received(1).DoorUnlock();
            _logFile.Received(1).logDoorUnlocked(2);
            Assert.That(_uut._state, Is.EqualTo(StationControl.LadeskabState.Available));
        }

        


    }
}

    
