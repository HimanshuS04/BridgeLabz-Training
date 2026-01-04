using System;

class VehicalRegistration
{
    public static int RegistrationFee = 2000;
    public readonly string RegistrationNumber;
    public string OwnerName;
    public string VehicleType;

    public VehicalRegistration(string OwnerName, string VehicleType, string RegistrationNumber)
    {
        this.OwnerName = OwnerName;
        this.VehicleType = VehicleType;
        this.RegistrationNumber = RegistrationNumber;
    }

    public static void UpdateRegistrationFee(int fee)
    {
        RegistrationFee = fee;
    }
//display details of vehical
    public void Display(object obj)
    {
        if (obj is VehicalRegistration)
        {
            Console.WriteLine(OwnerName + " - " + VehicleType);
        }
    }
}

class Program
{
    static void Main()
    {
        VehicalRegistration v1 = new VehicalRegistration("Rahul", "Car", "MH12AB1234");
        v1.Display(v1);
    }
}
