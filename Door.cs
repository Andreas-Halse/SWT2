using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Door : IDoor
    {

        public class DoorEventArgs : EventArgs
        {
<<<<<<< Updated upstream
            //public DoorStatus doorStatus { get; set; }
        }

       // private DoorStatus currentDoorStatus;
=======
          //  public DoorStatus doorStatus { get; set; }
        }

        //private DoorStatus currentDoorStatus;
>>>>>>> Stashed changes
        
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
