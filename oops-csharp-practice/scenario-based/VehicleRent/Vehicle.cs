using System;
public abstract class Vehicle : IRentable
{
    protected int vehicleId;
    protected string brand;
    protected decimal rentPerDay;
    protected decimal rentPerHour;
    protected bool isAvailable;

    protected Vehicle(int id, string brand, decimal dayRent, decimal hourRent)
    {
        vehicleId = id;
        this.brand = brand;
        rentPerDay = dayRent;
        rentPerHour = hourRent;
        isAvailable = true;
    }

    public int VehicleId => vehicleId;
    public string Brand => brand;
    public bool IsAvailable => isAvailable;
    public decimal RentPerDay => rentPerDay;
    public decimal RentPerHour => rentPerHour;

    public void Rent()
    {
        isAvailable = false;
    }

    public abstract decimal CalculateRent(int duration, bool isHourly);
}
