using System;
class Vehicle
{
    private string VehicleNumber;

    public void SetVehicleNumber(string number)
    {
        VehicleNumber = number;
    }
    public string GetVehicleNumber()
    {
        return VehicleNumber;
    }
    public override string ToString()
    {
        return $"Vehicle Number: {VehicleNumber}";
    }
}