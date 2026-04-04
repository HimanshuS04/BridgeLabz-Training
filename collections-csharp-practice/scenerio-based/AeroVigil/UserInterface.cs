using System;

public class UserInterface
{
    public static void Main()
    {
        try
        {
            Console.WriteLine("Enter flight details");
            string input = Console.ReadLine();

            string[] details = input.Split(':');

            string flightNumber = details[0];
            string flightName = details[1];
            int passengerCount = int.Parse(details[2]);
            double currentFuelLevel = double.Parse(details[3]);

            FlightUtil util = new FlightUtil();

            util.ValidateFlightNumber(flightNumber);
            util.ValidateFlightName(flightName);
            util.ValidatePassengerCount(passengerCount, flightName);

            double fuelRequired =
                util.CalculateFuelToFillTank(flightName, currentFuelLevel);

            Console.WriteLine(
                "Fuel required to fill the tank: " + fuelRequired + " liters");
        }
        catch (InvalidFlightException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (Exception)
        {
            // Handles format issues safely
        }
    }
}
