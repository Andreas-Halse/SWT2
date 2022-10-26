using System;
using System.IO;
using ClassLibrary;
using NUnit.Framework;
using SWT2;

namespace SWT2_Test
{
  

    [TestFixture]
    public class StationControl_Test
    {
        [SetUp]
        public void Setup()
        {
            //IChargeControl mockCharge= new MockChargeControl();

        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }



        #region StationControlTests
        /*
        [TestCase(true, StationControl.LadeskabState.DoorOpen)]
        [TestCase(false, StationControl.LadeskabState.Available)]
        public void DoorStateChangeEvent(bool doorState, StationControl.LadeskabState expectedState)
        {
            IChargeControl stubChargeControl = new StubChargeControl();
            IDisplay stubDisplay = new StubDisplay();
            IRFIDReader stubRfidReader = new StubRfidReader();
            ILogFile stubLogFile = new StubLogFile();
            IDoor stubDoor = new StubDoor();

            StationControl uut = new StationControl(stubChargeControl, stubDoor, stubDisplay, stubRfidReader, stubLogFile);



            Assert.AreSame(uut.DoorState, expectedState);
        }
        */
#endregion


    }
}

    
