using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWT2;
using System.IO;
using ClassLibrary;

namespace SWT2_Test_2
{
    [TestFixture]
    internal class LogFileTest
    {
        [SetUp]
        public void Setup()
        {
           
        }

        [Test]
        public void LockedTest()
        {
            if (File.Exists("logFile.txt"))
            {
                File.Delete("logFile.txt");
            }
            ILogFile uut = new logFile();
            uut.logDoorLocked(4444);

            string text = File.ReadAllText("logFile.txt");
            

            Assert.That(text, Contains.Substring("4444")); // Fucked test spørg Frank
        }

        [Test]
        public void UnlockedTest()
        {
            if (File.Exists("logFile.txt"))
            {
                File.Delete("logFile.txt");
            }
            ILogFile uut = new logFile();
            uut.logDoorUnlocked(4444);

            string text = File.ReadAllText("logFile.txt");


            Assert.That(text, Contains.Substring("4444")); // Fucked test spørg Frank
        }

        [Test]
        public void FileExistsTest()
        {
            ILogFile uut = new logFile();
            uut.logDoorLocked(4444);

            Assert.That(File.Exists("logFile.txt") == true);
        }
    }
}
