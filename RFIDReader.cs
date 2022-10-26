

namespace ClassLibrary
{
   
    public class RFIDReader : IRFIDReader
    {
        private int _id;

        public void RfidDetected(int id)
        {
            _id = id;
        }

        public event EventHandler<RFIDReader> RfidDeteced;
    }

    interface IRFIDReader
    {

    }



}
