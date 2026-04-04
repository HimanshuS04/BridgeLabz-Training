
using System;
class SmartHomeDevice
{
    public int DeviceId;
    public string Status;
}
class Thermostat : SmartHomeDevice
{
    public int TemperatureSetting;
    public void DisplayStatus()
    {
        Console.WriteLine(DeviceId + " " + Status + " " + TemperatureSetting);
    }
}
class Program
{
    static void Main()
    {
        Thermostat t = new Thermostat();
        t.DeviceId = 1;
        t.Status = "ON";
        t.TemperatureSetting = 24;
        t.DisplayStatus();
    }
}
