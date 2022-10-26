using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Door : IDoor
    {
        //event stuff start
        
        //attatch - subject/publisher side
        
        public class DoorEventArgs : EventArgs
        {
            public DoorStatus doorStatus { get; set; }
        }
        
        private DoorStatus currentDoorStatus;

        public event EventHandler<DoorEventArgs> DoorStatusEvent;
        //update - subject/publisher side

        private OnNewDoorStatus()
        {
            DoorStatusEvent?.Invoke(this, new DoorStatusEventArgs() {DoorStatus = currentDoorStatus});
        }
        
        //event stuff end
        
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
