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
        public event EventHandler<DoorEventArgs> DoorStateChange;   //"DoorStateChange" er det eventet skal triggeres på
                                                                    //"DoorEventArgs" er argumenterne der er inkluderet i hvad der sendes af eventet
        protected virtual void OnDoorStateChange()
        {
            DoorStateChange?.Invoke(this, new DoorEventArgs() {open = this._open}); //lokal variabel med bundstreg "_open"
        }
        //event stuff end
        
        Door()
        {
            _open = false; 
        }
        public bool locked { get; set; }    //bool for om døren er låst
        public bool _open { get; set; }     //bool for om døren er åben

        public void DoorOpened()
        {
            _open = true;
            OnDoorStateChange();    //event called
        }

        public void DoorClosed()
        {
            _open = false;
            OnDoorStateChange();    //event called
        }

        public void DoorUnlock()    //denne funktion kan kaldes af stationControl
        {
            locked = false;
        }

        public void DoorLock()      //denne funktion kan kaldes af stationControl
        {
            locked = true;
        }

    }
}
