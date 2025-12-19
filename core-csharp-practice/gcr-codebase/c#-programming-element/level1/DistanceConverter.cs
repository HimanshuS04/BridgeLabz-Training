using System;

class DistanceConverter
{
    static void Main(string[] args)
    {
        double dFeet;

        // Input
        dFeet = Convert.ToDouble(Console.ReadLine());

        // Convert to yards (1 yard = 3 feet)
        double distInYards = dFeet / 3.0;

        // Convert to miles (1 mile = 1760 yards)
        double distInMiles = distInYards / 1760.0;

        // Optional: Round values to 2 decimal places
        distInYards = Math.Round(distInYards, 2);
        distInMiles = Math.Round(distInMiles, 5); // miles may be small

        // Output
        Console.WriteLine("The distance in yards is " + distInYards +" and in miles is " + distInMiles);
    }
}
