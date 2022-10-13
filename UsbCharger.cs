using System;

namespace ClassLibrary
{

    public delegate void Notify(); //delegate
    public class UsbCharger : IUsbCharger
    {
        // Event triggered on new current value
        public event EventHandler<CurrentEventArgs> CurrentValueEvent;

        UsbCharger()
        {
            CurrentValue = new CurrentEventArgs().Current;
            CurrentValueEvent += StopCharge;
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
        public void StopCharge(object? sender, CurrentEventArgs e)
        {
        }
        {

        }
    }
}