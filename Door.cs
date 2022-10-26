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
        public event EventHandler<DoorEventArgs> DoorStateChange;

        private void OnDoorStateChange()
        {
            DoorStateChange?.Invoke(this, new DoorEventArgs() {locked = this.locked});
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
            locked = false;
            OnDoorStateChange();
        }

        public void DoorLock()
        {
            //Give message to StationControl that door is locked. 
            locked = true;
            OnDoorStateChange();
        }
    }
}
