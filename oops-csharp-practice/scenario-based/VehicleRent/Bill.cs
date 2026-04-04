using System;
public class Bill
{
    public static void Print(Vehicle vehical, int duration, bool isHourly, decimal amount)
    {
        Console.WriteLine("  BILL DETAILS  ");
        Console.WriteLine($"Vehicle ID : {vehical.VehicleId}");
        Console.WriteLine($"Brand      : {vehical.Brand}");
        Console.WriteLine($"Rent Type  : {(isHourly ? "Hourly" : "Daily")}");
        Console.WriteLine($"Duration   : {duration}");
        Console.WriteLine($"Total Cost : ₹{amount}");
    }
}
