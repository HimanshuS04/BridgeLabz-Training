using System;

// Driver class
class Driver
{
    public void Drive(Bus bus)
    {
        bus.MoveToNextStop();
    }
}

// Passenger class
class Passenger
{
    public string Name;
    public bool IsOnBus;

    public Passenger(string name)
    {
        Name = name;
        IsOnBus = true;
    }

    public bool WantToGetOff()
    {
        Console.Write(Name + ", do you want to get off? (y/n): ");
        char choice = Convert.ToChar(Console.ReadLine());

        if (choice == 'y' || choice == 'Y')
        {
            IsOnBus = false;
            return true;
        }
        return false;
    }
}
