using System;

class MathUtility
{
    static void Main()
    {
        int choice;

        do
        {
            Console.WriteLine("\n=== Math Utility Tool ===");
            Console.WriteLine("1. Factorial");
            Console.WriteLine("2. Prime Check");
            Console.WriteLine("3. GCD");
            Console.WriteLine("4. Fibonacci");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice: ");
            choice = int.ParseConsole.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter a number: ");
                    int num = int.ParseConsole.ReadLine());
                    Console.WriteLine("Factorial = " + Factorial(num));
                    break;

                case 2:
                    Console.Write("Enter a number: ");
                    int primeNum = int.ParseConsole.ReadLine());
                    Console.WriteLine(IsPrime(primeNum) ? "Prime Number" : "Not Prime");
                    break;

                case 3:
                    Console.Write("Enter first number: ");
                    int a = int.ParseConsole.ReadLine());
                    Console.Write("Enter second number: ");
                    int b = int.ParseConsole.ReadLine());
                    Console.WriteLine("GCD = " + GCD(a, b));
                    break;

                case 4:
                    Console.Write("Enter n: ");
                    int n = int.ParseConsole.ReadLine());
                    Console.WriteLine("Fibonacci(" + n + ") = " + Fibonacci(n));
                    break;

                case 5:
                    Console.WriteLine("Exiting...");
                    break;

                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }

        } while (choice != 5);
    }

   

    // Factorial Method
    static int Factorial(int n)
    {
        if (n < 0)
        {
            Console.WriteLine("Factorial not for negative numbers.");
            return -1;
        }

        int fact = 1;

        for (int i = 1; i <= n; i++)
        {
            fact *= i;
        }

        return fact;
    }

    // Prime Number Check
    static bool IsPrime(int n)
    {
        //  Prime numbers are greater than 1
        if (n <= 1)
            return false;

        //  Check divisibility up to n/2
        for (int i = 2; i <= n / 2; i++)
        {
            if (n % i == 0)
                return false;
        }

        return true;
    }

    // GCD using Euclidean Algorithm
    static int GCD(int a, int b)
    {
        //  GCD should always be positive
        a = Math.Abs(a);
        b = Math.Abs(b);

        // Repeat until remainder becomes zero
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }

        return a;
    }

    // Fibonacci Method
    static int Fibonacci(int n)
    {
        if (n < 0)
        {
            Console.WriteLine("Invalid input.");
            return -1;
        }

        if (n == 0) return 0;
        if (n == 1) return 1;

        int a = 0, b = 1, sum = 0;

        // HOW: Add previous two numbers
        for (int i = 2; i <= n; i++)
        {
            sum = a + b;
            a = b;
            b = sum;
        }

        return sum;
    }
}
