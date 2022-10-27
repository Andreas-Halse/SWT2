using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWT2
{
    public interface ILogFile
    {
        void logDoorLocked(int id);
        void logDoorUnlocked(int id);

    }

    public class logFile : ILogFile
    {
        public void logDoorLocked(int id)
        {
            using (StreamWriter writer = new StreamWriter("logFile.txt"))
            {
                String timeStamp = GetTimestamp(DateTime.Now);
                writer.WriteLine(timeStamp);
                writer.WriteLine("Id: " + id);
                writer.WriteLine("RFID has locked the door.");
            }
        }


        public void logDoorUnlocked(int id)
        {
            using (StreamWriter writer = new StreamWriter("logFile.txt"))
            {
                String timeStamp = GetTimestamp(DateTime.Now);
                writer.WriteLine(timeStamp);
                writer.WriteLine("Id: " + id);
                writer.WriteLine("RFID has unlocked the door.");
            }
        }

        // Function to get timestamp in string
        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssffff");
        }

    }
}
