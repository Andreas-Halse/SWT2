using System;
using System.IO;

namespace SWT2_Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
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

        }

        #endregion
    }
}