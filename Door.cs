using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargeStation
{
    interface IDoor
    {
        void OnDoorOpen();

        void OnDoorClose();

        bool OnDoorState(bool state);
    }

   


    public class Door : IDoor
    {
        public void OnDoorOpen()
        {
            // Write something to console
            OnDoorState(true);
        }

        public void OnDoorClose()
        {

        }

        public bool OnDoorState(bool state)
        {
            return state;
        }
    }
}
