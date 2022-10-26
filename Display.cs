using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public interface IDisplay
    {
        void Connection();
        void LoadRFID();
        void ConnectionError();
        void Occupied();
        void RFIDError();
        void RemovePhone();
        void FullyCharged();
        void PhoneCharging();
        void ChargeError();
    }

    public class Display : IDisplay
    {

        public void Connection()
        {
            string connectionString = "Phone is connected";
            System.Console.WriteLine(connectionString);
        }

        public void LoadRFID()
        {
            string loadRFIDString = "Load your RFID";
            System.Console.WriteLine(loadRFIDString);
        }

        public void ConnectionError()
        {
            string connectionErrorString = "Phone is NOT connected - an error occurred";
            System.Console.WriteLine(connectionErrorString);
        }

        public void Occupied()
        {
            string occupiedString = "Charger is occupied";
            System.Console.WriteLine(occupiedString);
        }

        public void RFIDError()
        {
            string RFIDErrorString = "RFID not loaded - an error occurred";
            System.Console.WriteLine(RFIDErrorString);
        }

        public void RemovePhone()
        {
            string removePhoneString = "Please remove phone";
            System.Console.WriteLine(removePhoneString);
        }

        public void FullyCharged()
        {
            string fullyChargedString = "Phone is fully charged";
            System.Console.WriteLine(fullyChargedString);
        }

        public void PhoneCharging()
        {
            string phoneChargingString = "Phone is charging";
            System.Console.WriteLine(phoneChargingString);
        }

        public void ChargeError()
        {
            string chargeErrorString = "Phone is NOT Charging - an error occurred";
            System.Console.WriteLine(chargeErrorString);
        }

    }
}
