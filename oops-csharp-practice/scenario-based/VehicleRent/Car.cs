using System;
public sealed class Car : Vehicle
{
    public Car(int id, string brand)
        : base(id, brand, 1000, 150) { }

    public override decimal CalculateRent(int duration, bool isHourly)
    {
        return isHourly ? rentPerHour * duration : rentPerDay * duration;
    }
}
