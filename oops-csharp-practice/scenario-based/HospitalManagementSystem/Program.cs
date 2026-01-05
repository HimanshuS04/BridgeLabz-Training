using System;

public class Program
{
    public static void Main()
    {
        // Create doctors
        Doctor drSmith = new Doctor("Dr. Sarah Smith", "Cardiology");
        Doctor drJones = new Doctor("Dr. Mark Jones", "General");

        // Create patients (Inheritance + Polymorphism)
        Patient inPatient = new InPatient(
            1,
            "Alice Johnson",
            28,
            305,
            DateTime.Now,
            drSmith
        );

        Patient outPatient = new OutPatient(
            2,
            "Bob Chen",
            45,
            DateTime.Now,
            drJones
        );

        // Polymorphic calls
        inPatient.DisplayInfo();
        Console.WriteLine();
        outPatient.DisplayInfo();
        Console.WriteLine();

        // Bills (Abstraction via IPayable)
        IPayable inPatientBill = new Bill("B001", inPatient, 15000.00m);
        IPayable outPatientBill = new Bill("B002", outPatient, 2500.00m);

        inPatientBill.ProcessPayment();
        outPatientBill.ProcessPayment();

        Console.WriteLine();
        inPatientBill.PrintReceipt();
        Console.WriteLine();
        outPatientBill.PrintReceipt();
    }
}
