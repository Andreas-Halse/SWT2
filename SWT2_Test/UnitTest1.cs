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
}