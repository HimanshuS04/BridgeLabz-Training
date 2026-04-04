using System;

class Program
{
    static void Main()
    {
        Bike[] bikes =
        {
            new Bike(101, "Yamaha"),
            new Bike(102, "Suzuki"),
            new Bike(103, "Honda"),
            new Bike(104, "Bajaj"),
            new Bike(105, "TVS"),
            new Bike(106, "Hero"),
            new Bike(107, "Kawasaki")
        
        };

        Car[] cars =
        {
            new Car(201, "Hyundai"),
            new Car(202, "Toyota"),
            new Car(203, "Ford"),
            new Car(204, "Honda"),
            new Car(205, "Skoda"),
            new Car(206, "Volkswagen"),
            new Car(207, "Mercedes-Benz")
        };

        Truck[] trucks =
        {
            new Truck(301, "Tata"),
            new Truck(302, "Ashok Leyland"),
            new Truck(303, "Mahindra"),
            new Truck(304, "Eicher"),
            new Truck(305, "BharatBenz"),
            new Truck(306, "Volvo")
        };

        while (true)
        {
            Console.WriteLine(" VEHICLE RENTAL SYSTEM ");
            Console.WriteLine("1. Bike");
            Console.WriteLine("2. Car");
            Console.WriteLine("3. Truck");
            Console.WriteLine("4. Exit");
            Console.Write("Choose vehicle types: ");

            int types = int.Parse(Console.ReadLine());

            if (types == 4) break;

            if (types == 1)
                RentVehicle(bikes);
            else if (types == 2)
                RentVehicle(cars);
            else if (types == 3)
                RentVehicle(trucks);
            else
                Console.WriteLine("Invalid choice!");
        }
    }

    static void RentVehicle(Vehicle[] vehicles)
    {
        Console.WriteLine("\nAvailable Vehicles:");
        for (int i = 0; i < vehicles.Length; i++)
        {
            if (vehicles[i].IsAvailable)
            {
                Console.WriteLine(
                    $"ID: {vehicles[i].VehicleId}, Brand: {vehicles[i].Brand}, " +
                    $"Day: ₹{vehicles[i].RentPerDay}, Hour: ₹{vehicles[i].RentPerHour}"
                );
            }
        }

        Console.Write("\nEnter Vehicle ID to rent: ");
        int id = int.Parse(Console.ReadLine());

        Vehicle selected = null;

        for (int i = 0; i < vehicles.Length; i++)
        {
            if (vehicles[i].VehicleId == id && vehicles[i].IsAvailable)
            {
                selected = vehicles[i];
                break;
            }
        }

        if (selected == null)
        {
            Console.WriteLine("Vehicle not available!");
            return;
        }

        Console.WriteLine("1. Rent by Days");
        Console.WriteLine("2. Rent by Hours");
        Console.Write("Choose option: ");
        int option = int.Parse(Console.ReadLine());

        bool isHourly = option == 2;

        Console.Write($"Enter {(isHourly ? "hours" : "days")}: ");
        int duration = int.Parse(Console.ReadLine());

        decimal amount = selected.CalculateRent(duration, isHourly);
        selected.Rent();

        Bill.Print(selected, duration, isHourly, amount);
    }
}
