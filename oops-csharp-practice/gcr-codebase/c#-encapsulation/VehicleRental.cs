using System;

interface IInsurable
{
    double CalculateInsurance();
    string GetInsuranceDetails();
}

abstract class Vehicle
{
    protected string vehicleNumber;
    protected double rentalRate;

    public Vehicle(string number, double rate)
    {
        vehicleNumber = number;
        rentalRate = rate;
    }

    public abstract double CalculateRentalCost(int days);
}

class Car : Vehicle, IInsurable
{
    public Car(string number) : base(number, 1500) { }

    public override double CalculateRentalCost(int days)
    {
        return rentalRate * days;
    }

    public double CalculateInsurance()
    {
        return 500;
    }

    public string GetInsuranceDetails()
    {
        return "Car Insurance";
    }
}

class Bike : Vehicle
{
    public Bike(string number) : base(number, 500) { }

    public override double CalculateRentalCost(int days)
    {
        return rentalRate * days;
    }
}
