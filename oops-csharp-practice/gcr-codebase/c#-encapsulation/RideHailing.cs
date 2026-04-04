using System;

interface IGPS
{
    string GetCurrentLocation();
    void UpdateLocation(string location);
}

abstract class Vehicle
{
    protected string driverName;
    protected double ratePerKm;

    public Vehicle(string driver, double rate)
    {
        driverName = driver;
        ratePerKm = rate;
    }

    public abstract double CalculateFare(double distance);
}

class Car : Vehicle
{
    public Car(string driver) : base(driver, 15) { }

    public override double CalculateFare(double distance)
    {
        return distance * ratePerKm;
    }
}
