using System;

class Program
{
    static void Main(string[] args)
    {
        Bus bus = new Bus(10);     // 10 km per stop
        Driver driver = new Driver();

        // Multiple passengers
        Passenger[] passengers =
        {
            new Passenger("Amit"),
            new Passenger("Riya"),
            new Passenger("Karan")
        };

        int choice;
        bool journeyRunning = true;

        do
        {
            Console.WriteLine(" Bus Route System ");
            Console.WriteLine("1. Driver (Move Bus)");
            Console.WriteLine("2. Passenger Actions");
            Console.WriteLine("3. Exit");
            Console.Write("Enter choice: ");

            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    driver.Drive(bus);
                    break;

                case 2:
                    foreach (Passenger p in passengers)
                    {
                        if (p.IsOnBus)
                        {
                            if (p.WantToGetOff())
                            {
                                Console.WriteLine(p.Name + " got off at Stop " + bus.StopNumber);
                            }
                        }
                    }

                    // Check if all passengers got off
                    bool anyOnBus = false;
                    foreach (Passenger p in passengers)
                    {
                        if (p.IsOnBus)
                            anyOnBus = true;
                    }

                    if (!anyOnBus)
                    {
                        Console.WriteLine("All passengers have exited.");
                        Console.WriteLine("Final Distance: " + bus.TotalDistance + " km");
                        journeyRunning = false;
                    }
                    break;

                case 3:
                    journeyRunning = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }

        } while (journeyRunning);

        Console.WriteLine("Journey Ended ");
    }
}
