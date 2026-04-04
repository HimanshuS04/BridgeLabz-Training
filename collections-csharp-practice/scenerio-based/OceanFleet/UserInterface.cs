using System;
using System.Collections.Generic;

public class UserInterface
{
    public static void Main(string[] args)
    {
        VesselUtil util = new VesselUtil();

        Console.WriteLine("Enter the number of vessels to be added");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter vessel details");

        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();
            string[] parts = input.Split(':');

            Vessel vessel = new Vessel(
                parts[0],
                parts[1],
                double.Parse(parts[2]),
                parts[3]
            );

            util.AddVesselPerformance(vessel);
        }

        Console.WriteLine("Enter the Vessel Id to check speed");
        string searchId = Console.ReadLine();

        Vessel found = util.GetVesselById(searchId);

        if (found != null)
        {
            Console.WriteLine($"{found.VesselId} | {found.VesselName} | {found.VesselType} | {found.AverageSpeed} knots");
        }
        else
        {
            Console.WriteLine($"Vessel Id {searchId} not found");
        }

        Console.WriteLine("High performance vessels are");

        List<Vessel> highPerformance = util.GetHighPerformanceVessels();

        foreach (Vessel vessel in highPerformance)
        {
            Console.WriteLine($"{vessel.VesselId} | {vessel.VesselName} | {vessel.VesselType} | {vessel.AverageSpeed} knots");
        }
    }
}
