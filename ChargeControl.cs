using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
  
    public class ChargeControl : IChargeControl
    {
        IUsbCharger _charger;
        IDisplay _display;

        ChargeControl(IUsbCharger charger, IDisplay display)
        {
            _charger = charger;
            _display = display;
            _charger.CurrentValueEvent += OnNewCurrent;
        }

        public bool IsConnected()
        {
            if (_charger.Connected == true)
            {
                
                return true;
            }
            else
            {
                return false;
            }
        }
        public void StartCharge()
        {
            _charger.StartCharge();
        }
        public void StopCharge()
        {
            _charger.StopCharge();
        }

        public void OnNewCurrent(object?, CurrentEventArgs e)
        {
            if (e.Current>5 && e.Current < 500)
            {
                _display.PhoneCharging();
            }
            else if (e.Current > 0 && e.Current < 5)
            {
                StopCharge();
                _display.FullyCharged();
            }
            else if (e.Current > 500)
            {
                StopCharge();
                _display.ChargeError();
            }
            else if (e.Current <= 0)
            {
                _display.ConnectionError();
            }
        }
        {

        }
    }

    
    
}
