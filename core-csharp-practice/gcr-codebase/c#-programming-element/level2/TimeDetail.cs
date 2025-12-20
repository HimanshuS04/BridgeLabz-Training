using System;

class TripDetail
{
    static void Main()
    {

        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter From City: ");
        string fromCity = Console.ReadLine();

        Console.Write("Enter Via City: ");
        string viaCity = Console.ReadLine();

        Console.Write("Enter To City: ");
        string toCity = Console.ReadLine();

        // Distance Inputs
        Console.Write("Enter distance from FromCity to ViaCity (miles): ");
        double fromToVia = double.Parse(Console.ReadLine());

        Console.Write("Enter distance from ViaCity to ToCity (miles): ");
        double viaToFinalCity = double.Parse(Console.ReadLine());

        // Time Input
        Console.Write("Enter time taken (hours): ");
        double timeTaken = double.Parse(Console.ReadLine());

        // Calculations
        double tDistance = fromToVia + viaToFinalCity;

        // Correct calculation
        double avgSpeed = tDistance / timeTaken;

        // Precedence example (WRONG logically but useful for learning)
        double pResult = fromToVia + viaToFinalCity / timeTaken;

        // Output
        Console.WriteLine(
            "The results of the trip are: " +
            "Total Distance = " + tDistance +
            " miles, Average Speed = " + avgSpeed +
            " mph, Precedence Result = " + pResult
        );
    }
}
