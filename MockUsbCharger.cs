using System;

namespace ClassLibrary
{
   

    public class MockUsbCharger : IUsbCharger
    {
        // Event triggered on new current value
        event EventHandler<CurrentEventArgs> CurrentValueEvent;

        MockUsbCharger()
        {
            CurrentValue = new CurrentEventArgs().Current;
        }

        // Direct access to the current current value
        public double CurrentValue { get; }

        // Require connection status of the phone
        public bool Connected { get; }

        // Start charging
        public void StartCharge()
        {

        }
        // Stop charging
        public void StopCharge()
        {

        }
    }
}