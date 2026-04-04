using System;

class BasicCalculator
{
    static double Add(double a, double b)
    {
        return a + b;
    }

    static double Subtract(double a, double b)
    {
        return a - b;
    }

    static double Multiply(double a, double b)
    {
        return a * b;
    }

    static double Divide(double a, double b)
    {
        return a / b;
    }

    static void Main()
    {
        Console.WriteLine("1. Addition");
        Console.WriteLine("2. Subtraction");
        Console.WriteLine("3. Multiplication");
        Console.WriteLine("4. Division");
        Console.Write("Choose operation: ");
        int choice = int.Parse(Console.ReadLine());

        Console.Write("Enter first number: ");
        double a = double.Parse(Console.ReadLine());

        Console.Write("Enter second number: ");
        double b = double.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                Console.WriteLine("Result = " + Add(a, b));
                break;
            case 2:
                Console.WriteLine("Result = " + Subtract(a, b));
                break;
            case 3:
                Console.WriteLine("Result = " + Multiply(a, b));
                break;
            case 4:
                if (b != 0)
                    Console.WriteLine("Result = " + Divide(a, b));
                else
                    Console.WriteLine("Division by zero not allowed");
                break;
            default:
                Console.WriteLine("Invalid choice");
                break;
        }
    }
}
