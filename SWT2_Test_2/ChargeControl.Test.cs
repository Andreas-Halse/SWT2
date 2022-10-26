using System;
using System.IO;
using ClassLibrary;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;
using SWT2;

namespace SWT2_Test
{

    [TestFixture]
    public class ChargeControl_Test
    {

        private ChargeControl _uut;

        private IUsbCharger _usbCharger;
        private IDisplay _display;
        [SetUp]
        public void Setup()
        {
            _usbCharger = Substitute.For<IUsbCharger>();
            _display = Substitute.For<IDisplay>();
            _uut = new ChargeControl(_usbCharger, _display);


        }

        [Test]
        public void ChargeControl_Connected()
        {
            _usbCharger.Connected.Returns(true);
            Assert.That(_uut.IsConnected(), Is.EqualTo(true));

            _usbCharger.Connected.Returns(false);
            Assert.That(_uut.IsConnected(), Is.EqualTo(false));
        }

        [Test]
        public void ChargeControl_StartCharge()
        {
            _uut.StartCharge();
            _usbCharger.Received(1).StartCharge();
        }
        public void ChargeControl_StopCharge()
        {
            _uut.StopCharge();
            _usbCharger.Received(1).StopCharge();
        }

        [Test]
        public void ChargeControl_OnNewCurrent()
        {
            _usbCharger.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs() { Current = 0 });
            _usbCharger.Received(1).StopCharge();
            _display.Received(1).FullyCharged();
            _usbCharger.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs() { Current = 5 });
            _display.Received(1).PhoneCharging();
            _usbCharger.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs() { Current = 500 });
            _usbCharger.Received(1).StopCharge();
            _display.Received(1).ChargeError();
            _usbCharger.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs() { Current = -1 });
            _display.Received(1).ConnectionError();
        }




    


    }
}

    
