using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{

    public class RFIDEventArgs : EventArgs
    {
        public int id { get; set; }
    }

    public interface IRFIDReader
    {
        public event EventHandler<RFIDEventArgs> RfidDeteced;

        void RFIDTagReader(int id);

    }
    
    
}
