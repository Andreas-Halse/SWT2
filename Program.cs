    using ChargeStation;

    class Program
    {
        static void Main(string[] args)
        {
				// Assemble your system here from all the classes

            bool finish = false;
            do
            {
                string input;
                Door door = new Door();
                System.Console.WriteLine("Indtast E, O, C, R: ");
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input)) continue;

                switch (input[0])
                {
                    case 'E':
                        finish = true;
                        break;

                    case 'O':
                        door.OnDoorOpen();
                        break;

                    case 'C':
                        door.OnDoorClose();
                        break;

                    case 'R':
                        System.Console.WriteLine("Indtast RFID id: ");
                        string idString = System.Console.ReadLine();

                        int id = Convert.ToInt32(idString);
                        //rfidReader.OnRfidRead(id);
                        break;

                    default: //secret message for Andreas
                        break;
                }

            } while (!finish);
        }
    }

