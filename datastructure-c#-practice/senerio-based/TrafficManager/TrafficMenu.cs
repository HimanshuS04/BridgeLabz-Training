using System;

public class TrafficMenu
{
    private ITrafficManager manager;

    public TrafficMenu()
    {
        manager = new TrafficUtilityImpl();
    }

    public void Start()
    {
        while (true)
        {
            Console.WriteLine("=== Traffic Manager Menu ===");
            Console.WriteLine("1. Add Vehicle to Waiting Queue");
            Console.WriteLine("2. Allow Vehicle into Roundabout");
            Console.WriteLine("3. Exit Vehicle from Roundabout");
            Console.WriteLine("4. Print Roundabout");
            Console.WriteLine("5. Exit");
            Console.Write("Enter choice: ");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    manager.AddVehicleToQueue();
                    break;
                case 2:
                    manager.AllowVehicleIntoRoundabout();
                    break;
                case 3:
                    manager.ExitVehicleFromRoundabout();
                    break;
                case 4:
                    manager.PrintRoundabout();
                    break;
                case 5:
                    return;
                default:
                    Console.WriteLine("Choose between 1–5.");
                    break;
            }
        }
    }
}