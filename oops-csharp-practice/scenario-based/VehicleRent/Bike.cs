using System;
public sealed class Bike : Vehicle
{
    public Bike(int id, string brand)
        : base(id, brand, 300, 45) { }

    public override decimal CalculateRent(int duration, bool isHourly)
    {
        return isHourly ? rentPerHour * duration : rentPerDay * duration;
    }
}
