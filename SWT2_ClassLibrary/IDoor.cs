using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    
    public class DoorEventArgs : EventArgs
    {
        public bool open { get; set; }
    }
    
    public interface IDoor
    {
        public event EventHandler<DoorEventArgs> DoorStateChange;

        bool _open { get; set; }
        bool locked { get; }
        void DoorOpened();
        void DoorClosed();
        void DoorUnlock();
        void DoorLock();
    }
}