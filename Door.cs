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

        protected virtual void OnDoorStateChange()
        {
            DoorStateChange?.Invoke(this, new DoorEventArgs() {open = this._open}); //lokal variabel = _open
        }
        
        //event stuff end
        Door()
        {
            _open = false; 
        }
        public bool locked { get; set; }
        public bool _open { get; set; }

        public void DoorOpened()
        {
            _open = true;
            OnDoorStateChange();
        }

        public void DoorClosed()
        {
            _open = false;
            OnDoorStateChange();
        }




        public void DoorUnlock()
        {
            //Give message to StationControl that door is unlocked.
            locked = false;
        }

        public void DoorLock()
        {
            //Give message to StationControl that door is locked. 
            locked = true;
        }

        
    }
}
