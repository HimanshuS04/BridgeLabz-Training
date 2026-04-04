
using System;
interface Refuelable
{
    void Refuel();
}
class Vehicle
{
    public int MaxSpeed;
    public string Model;
}
class ElectricVehicle : Vehicle
{
    public void Charge(){ Console.WriteLine("Charging vehical"); }
}
class PetrolVehicle : Vehicle, Refuelable
{
    public void Refuel(){ Console.WriteLine("Refueling vehical"); }
}
class Program
{
    static void Main()
    {
        PetrolVehicle p = new PetrolVehicle();
        p.Refuel();
    }
}
