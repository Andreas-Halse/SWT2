

namespace ClassLibrary
{
   
    public class RFIDReader : IRFIDReader
    {

        private int _ID;
        
        public void RFIDTagReader(int id)
        {
            _ID = id;
        }

        //Event starts
        public event EventHandler <RFIDEventArgs> RfidDeteced;

       
        protected virtual void OnRfidDetected()
        {
          RfidDeteced?.Invoke(this, new RFIDEventArgs() {id = this._ID});
        }
// Event ends
    }

    
}
