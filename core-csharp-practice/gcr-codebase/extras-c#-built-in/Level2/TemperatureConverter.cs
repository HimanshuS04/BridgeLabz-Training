using System;

class TemperatureConverter
{
    static double FahrenheitToCelsius(double f)
    {
        return (f - 32) * 5 / 9;
    }

    static double CelsiusToFahrenheit(double c)
    {
        return (c * 9 / 5) + 32;
    }

    static void Main()
    {
        Console.WriteLine("1. Fahrenheit to Celsius");
        Console.WriteLine("2. Celsius to Fahrenheit");
        Console.Write("Choose option: ");
        int choice = Convert.ToInt32(Console.ReadLine());

        if (choice == 1)
        {
            Console.Write("Enter temperature in Fahrenheit: ");
            double f = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Celsius = " + FahrenheitToCelsius(f));
        }
        else if (choice == 2)
        {
            Console.Write("Enter temperature in Celsius: ");
            double c = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Fahrenheit = " + CelsiusToFahrenheit(c));
        }
        else
        {
            Console.WriteLine("Invalid choice");
        }
    }
}
