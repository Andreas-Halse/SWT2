using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    
    public class DoorEventArgs : EventArgs
    {
        public bool locked { get; set; }
    }
    
    public interface IDoor
    {
        public event EventHandler<DoorEventArgs> DoorStateChange;

        bool locked { get; }
        void DoorUnlock();

        void DoorLock();
    }
}