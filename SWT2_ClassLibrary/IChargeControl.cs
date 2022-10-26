namespace ClassLibrary;

public interface IChargeControl
{
    bool IsConnected();
    void StartCharge();
    void StopCharge();
}