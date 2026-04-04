using System;
public sealed class Truck : Vehicle
{
    public Truck(int id, string brand)
        : base(id, brand, 2000, 300) { }

    public override decimal CalculateRent(int duration, bool isHourly)
    {
        return isHourly ? rentPerHour * duration : rentPerDay * duration;
    }
}
