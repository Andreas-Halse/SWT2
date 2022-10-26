using ClassLibrary;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWT2_Test_2
{
    [TestFixture]
    internal class DiplayTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]

        public void ConnectionTest()
        {
            var stringwriter = new StringWriter();
            Console.SetOut(stringwriter);

            IDisplay uut = new Display();
            uut.Connection();

            string actulstring = stringwriter.ToString();

            Assert.AreEqual(actulstring, "Please connect phone\r\n");

        }

        [Test]
        public void LoadRFIDTest()
        {
            var stringwriter = new StringWriter();
            Console.SetOut(stringwriter);

            IDisplay uut = new Display();
            uut.LoadRFID();

            string actulstring = stringwriter.ToString();

            Assert.AreEqual(actulstring, "Load your RFID\r\n");
        }

        [Test]
        public void ConnectionErrorTest()
        {
            var stringwriter = new StringWriter();
            Console.SetOut(stringwriter);

            IDisplay uut = new Display();
            uut.ConnectionError();

            string actulstring = stringwriter.ToString();

            Assert.AreEqual(actulstring, "Phone is NOT connected - an error occurred\r\n");
        }

        [Test]
        public void OccupiedTest()
        {
            var stringwriter = new StringWriter();
            Console.SetOut(stringwriter);

            IDisplay uut = new Display();
            uut.Occupied();

            string actulstring = stringwriter.ToString();

            Assert.AreEqual(actulstring, "Charger is occupied\r\n");
        }

        [Test]
        public void RFIDErrorTest()
        {
            var stringwriter = new StringWriter();
            Console.SetOut(stringwriter);

            IDisplay uut = new Display();
            uut.RFIDError();

            string actulstring = stringwriter.ToString();

            Assert.AreEqual(actulstring, "RFID not loaded - an error occurred\r\n");
        }

        [Test]
        public void RemovePhoneTest()
        {
            var stringwriter = new StringWriter();
            Console.SetOut(stringwriter);

            IDisplay uut = new Display();
            uut.RemovePhone();

            string actulstring = stringwriter.ToString();

            Assert.AreEqual(actulstring, "Please remove phone\r\n");
        }

        [Test]
        public void FullyChargedTest()
        {
            var stringwriter = new StringWriter();
            Console.SetOut(stringwriter);

            IDisplay uut = new Display();
            uut.FullyCharged();

            string actulstring = stringwriter.ToString();

            Assert.AreEqual(actulstring, "Phone is fully charged\r\n");
        }

        [Test]
        public void PhoneChargingTest()
        {
            var stringwriter = new StringWriter();
            Console.SetOut(stringwriter);

            IDisplay uut = new Display();
            uut.PhoneCharging();

            string actulstring = stringwriter.ToString();

            Assert.AreEqual(actulstring, "Phone is charging\r\n");
        }

        [Test]
        public void ChargeErrorTest()
        {
            var stringwriter = new StringWriter();
            Console.SetOut(stringwriter);

            IDisplay uut = new Display();
            uut.ChargeError();

            string actulstring = stringwriter.ToString();

            Assert.AreEqual(actulstring, "Phone is NOT Charging - an error occurred\r\n");
        }

    }
}

