using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public interface IDoor
    {
        bool locked { get; }
        void DoorUnlock();

        void DoorLock();
    }

    public class Door : IDoor
    {
        public bool locked { get; set; }

        public Door()
        {
            locked = false; //Lav event 
        }
        
        public void DoorUnlock()
        {
            //Give message to StationControl that door is unlocked.
            
        }

        public void DoorLock()
        {
            //Give message to StationControl that door is locked. 
            
        }
    }
}
