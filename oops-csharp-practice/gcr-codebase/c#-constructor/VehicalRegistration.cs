using System;

class VehicalRegistration
{
    // Instance variables
    public string ownerName;
    public string VehicalRegistrationType;

    // Class variable
    public static double registrationFee = 5000;

    public VehicalRegistration(string owner, string type)
    {
        ownerName = owner;
        VehicalRegistrationType = type;
    }

    // Instance method
    public void DisplayVehicalRegistrationDetails()
    {
        Console.WriteLine("Owner Name      : " + ownerName);
        Console.WriteLine("VehicalRegistration Type    : " + VehicalRegistrationType);
        Console.WriteLine("Registration Fee: " + registrationFee);
    }

    // Class method
    public static void UpdateRegistrationFee(double fee)
    {
        registrationFee = fee;
    }

    static void Main()
    {
        VehicalRegistration v1 = new VehicalRegistration("Ramesh", "Car");
        v1.DisplayVehicalRegistrationDetails();

        VehicalRegistration.UpdateRegistrationFee(6000);

        VehicalRegistration v2 = new VehicalRegistration("Suresh", "Bike");
        v2.DisplayVehicalRegistrationDetails();
    }
}
