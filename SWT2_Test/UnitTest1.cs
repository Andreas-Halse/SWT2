using System;
using System.IO;


using ClassLibrary;
using SWT2;

namespace SWT2_Test
{
    public class Tests
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




        #region DisplayTests

        [Test]
        public void outputTest()
        {
            var stringwriter = new StringWriter();
            Console.SetOut(stringwriter);
            string test = "test";
            Console.WriteLine(test);
            // assert that stringwriter now contains the correct string
        }

        [Test]
        public void ConnectionTest()
        {
            var stringwriter = new StringWriter();
            Console.SetOut(stringwriter);

            IDisplay uut = new Display();
            uut.Connection();

            string actulstring = stringwriter.ToString();

            Assert.Equals(actulstring, "Phone is connected");
            // Assert that stringwriter has the correct value
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

        }
        #endregion DisplayTests


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
}