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
}