using System;
using System.IO;


using ClassLibrary;

namespace SWT2_Test
{

    
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            IChargeControl mockCharge= new MockChargeControl();
            
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }




        #region DisplayTests

        [Test]
        public void outputTest()
        {
            var stringwriter = new StringWriter();
            Console.SetOut(stringwriter);
            string test = "test";
            Console.WriteLine(test);
        }

        [Test]
        public void ConnectionTest()
        {

        }

        [Test]
        public void LoadRFIDTest()
        {

        }

        [Test]
        public void ConnectionErrorTest()
        {

        }

        [Test]
        public void OccupiedTest()
        {

        }

        [Test]
        public void RFIDErrorTest()
        {

        }

        [Test]
        public void RemovePhoneTest()
        {

        }

        [Test]
        public void FullyChargedTest()
        {

        }

        [Test]
        public void PhoneChargingTest()
        {

        }

        [Test]
        public void ChargeErrorTest()
        {


        #region ChargeControlTests
        [Test]
        public void Test2()
        {
            Assert.Pass();
        }
        #endregion
       
        #region DoorTests
        [Test]
        public void DoorLockedTest()
        {
            IDoor door1 = new Door();
            bool test = door1.locked;
            Assert.That(test);
        }

        #endregion
    }

    #region Handout_tests

    

    [TestFixture]
    public class TestUsbChargerSimulator
    {
        private UsbChargerSimulator _uut;
        [SetUp]
        public void Setup()
        {
            _uut = new UsbChargerSimulator();
        }

        [Test]
        public void ctor_IsConnected()
        {
            Assert.That(_uut.Connected, Is.True);
        }

        [Test]
        public void ctor_CurentValueIsZero()
        {
            Assert.That(_uut.CurrentValue, Is.Zero);
        }

        [Test]
        public void SimulateDisconnected_ReturnsDisconnected()
        {
            _uut.SimulateConnected(false);
            Assert.That(_uut.Connected, Is.False);
        }

        [Test]
        public void Started_WaitSomeTime_ReceivedSeveralValues()
        {
            int numValues = 0;
            _uut.CurrentValueEvent += (o, args) => numValues++;

            _uut.StartCharge();

            System.Threading.Thread.Sleep(1100);

            Assert.That(numValues, Is.GreaterThan(4));
        }

        [Test]
        public void Started_WaitSomeTime_ReceivedChangedValue()
        {
            double lastValue = 1000;
            _uut.CurrentValueEvent += (o, args) => lastValue = args.Current;

            _uut.StartCharge();

            System.Threading.Thread.Sleep(300);

            Assert.That(lastValue, Is.LessThan(500.0));
        }

        [Test]
        public void StartedNoEventReceiver_WaitSomeTime_PropertyChangedValue()
        {
            _uut.StartCharge();

            System.Threading.Thread.Sleep(300);

            Assert.That(_uut.CurrentValue, Is.LessThan(500.0));
        }

        [Test]
        public void Started_WaitSomeTime_PropertyMatchesReceivedValue()
        {
            double lastValue = 1000;
            _uut.CurrentValueEvent += (o, args) => lastValue = args.Current;

            _uut.StartCharge();

            System.Threading.Thread.Sleep(1100);

            Assert.That(lastValue, Is.EqualTo(_uut.CurrentValue));
        }


        [Test]
        public void Started_SimulateOverload_ReceivesHighValue()
        {
            ManualResetEvent pause = new ManualResetEvent(false);
            double lastValue = 0;

            _uut.CurrentValueEvent += (o, args) =>
            {
                lastValue = args.Current;
                pause.Set();
            };

            // Start
            _uut.StartCharge();

            // Next value should be high
            _uut.SimulateOverload(true);

            // Reset event
            pause.Reset();

            // Wait for next tick, should send overloaded value
            pause.WaitOne(300);

            Assert.That(lastValue, Is.GreaterThan(500.0));
        }

        [Test]
        public void Started_SimulateDisconnected_ReceivesZero()
        {
            ManualResetEvent pause = new ManualResetEvent(false);
            double lastValue = 1000;

            _uut.CurrentValueEvent += (o, args) =>
            {
                lastValue = args.Current;
                pause.Set();
            };


            // Start
            _uut.StartCharge();

            // Next value should be zero
            _uut.SimulateConnected(false);

            // Reset event
            pause.Reset();

            // Wait for next tick, should send disconnected value
            pause.WaitOne(300);

            Assert.That(lastValue, Is.Zero);
        }

        [Test]
        public void SimulateOverload_Start_ReceivesHighValueImmediately()
        {
            double lastValue = 0;

            _uut.CurrentValueEvent += (o, args) =>
            {
                lastValue = args.Current;
            };

            // First value should be high
            _uut.SimulateOverload(true);

            // Start
            _uut.StartCharge();

            // Should not wait for first tick, should send overload immediately

            Assert.That(lastValue, Is.GreaterThan(500.0));
        }

        [Test]
        public void SimulateDisconnected_Start_ReceivesZeroValueImmediately()
        {
            double lastValue = 1000;

            _uut.CurrentValueEvent += (o, args) =>
            {
                lastValue = args.Current;
            };

            // First value should be high
            _uut.SimulateConnected(false);

            // Start
            _uut.StartCharge();

            // Should not wait for first tick, should send zero immediately

            Assert.That(lastValue, Is.Zero);
        }

        [Test]
        public void StopCharge_IsCharging_ReceivesZeroValue()
        {
            double lastValue = 1000;
            _uut.CurrentValueEvent += (o, args) => lastValue = args.Current;

            _uut.StartCharge();

            System.Threading.Thread.Sleep(300);

            _uut.StopCharge();

            Assert.That(lastValue, Is.EqualTo(0.0));
        }

        [Test]
        public void StopCharge_IsCharging_PropertyIsZero()
        {
            _uut.StartCharge();

            System.Threading.Thread.Sleep(300);

            _uut.StopCharge();

            Assert.That(_uut.CurrentValue, Is.EqualTo(0.0));
        }

        [Test]
        public void StopCharge_IsCharging_ReceivesNoMoreValues()
        {
            double lastValue = 1000;
            _uut.CurrentValueEvent += (o, args) => lastValue = args.Current;

            _uut.StartCharge();

            System.Threading.Thread.Sleep(300);

            _uut.StopCharge();
            lastValue = 1000;

            // Wait for a tick
            System.Threading.Thread.Sleep(300);

            // No new value received
            Assert.That(lastValue, Is.EqualTo(1000.0));
        }



    }
    #endregion


}