﻿using ClassLibrary;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWT2_Test_2
{

    [TestFixture]

    class TestRFIDReader
    {
        private RFIDReader _uut;
        private RFIDEventArgs _receivedEventArgs;

        [SetUp]
        public void Setup()
        {
            _receivedEventArgs = null;
            _uut = new RFIDReader();
            _uut.RFIDTagReader(2945);

            // Set up an event listener to check the event occurrence and event data
            _uut.RfidDetected +=
                (o, args) => { _receivedEventArgs = args; };
        }

        [Test]

        public void setRFIDTag() //Test that id sent is not null
        {
            _uut.RFIDTagReader(2945);
            Assert.That(_receivedEventArgs, Is.Not.Null);
        }
        
        [Test]
        public void setRFIDTag_CorrectValue() //Test that correct id is sent
        {
            _uut.RFIDTagReader(2945);
            Assert.That(_receivedEventArgs.id, Is.EqualTo(2945));
        }
        
        [Test]
        public void setRFIDTag_NotCorrectValue() //Test that correct id is not sent
        {
            _uut.RFIDTagReader(3333);
            Assert.AreNotEqual(_receivedEventArgs.id, (2945));
        }
    }
}

