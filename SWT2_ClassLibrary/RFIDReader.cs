

namespace ClassLibrary
{
   
    public class RFIDReader : IRFIDReader
    {

        private int _ID;
        
        public void RFIDTagReader(int id)
        {
            _ID = id; //Set IdTag
            OnRfidDetected(); //Call Event
        }

        //Event starts
        public event EventHandler <RFIDEventArgs> RfidDetected;

       
        protected virtual void OnRfidDetected()
        {
          RfidDetected?.Invoke(this, new RFIDEventArgs() {id = this._ID});
        }
// Event ends
    }

    
}
