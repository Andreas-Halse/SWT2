using System;
using ClassLibrary;
using SWT2;



namespace SWT2_Console
{
    
    class Program
    {
        static void Main(string[] args)
        {
            // Assemble your system here from all the classes
            IDoor door = new Door();
            IRFIDReader rfid = new RFIDReader();
            StationControl stationControl = new StationControl(door, rfid);
            bool finish = false;

            do
            {
                string input;

                System.Console.WriteLine("Indtast: \n" +
                                         "E = Exit\n" +
                                         "O = Open\n" +
                                         "C = Close\n" +
                                         "R = Read RFID");

                input = Console.ReadLine();

                if (string.IsNullOrEmpty(input)) continue;

                input = input.ToUpper();

                switch (input[0])
                {
                    case 'E':
                        finish = true;
                        break;

                    case 'O':
                        door.DoorOpened();
                        break;

                    case 'C':
                        door.DoorClosed();
                        break;
                        
                    case 'R':
                        System.Console.WriteLine("Indtast RFID id: ");
                        string idString = System.Console.ReadLine();

                        int id = Convert.ToInt32(idString);
                        rfid.RFIDTagReader(id);
                        break;

                    default:
                        break;
                }

            } while (!finish);
        }

    }

}
