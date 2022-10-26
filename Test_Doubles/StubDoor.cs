using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace SWT2.Stubs
{
    public class StubDoor : IDoor
    {

        StubDoor()
        {

        }
        public bool _open { get; set; }
        public bool locked { get; }
        public event EventHandler<DoorEventArgs> DoorStateChange;
        public void DoorOpened()
        {
            
        }
        public void DoorClosed()
        {

        }
        public void DoorUnlock()
        {

        }
        public void DoorLock()
        {

        }
    }
}
