using System;

class FibonacciGenerator
{
    public static void Main(string[] args)
    {
        Console.Write("Enter number of term: ");
        int term = int.Parse(Console.ReadLine());

        if (term <= 0)
        {
            Console.WriteLine("Please enter a positive number.");
            return;
        }

        GenerateFibonacci(term);
    }

    // Method to generate and print Fibonacci sequence
    static void GenerateFibonacci(int n)
    {
        int first = 0;
        int second = 1;

        Console.WriteLine("\nFibonacci Sequence:");

        for (int i = 1; i <= n; i++)
        {
            Console.Write(first + " ");

            int next = first + second;
            first = second;
            second = next;
        }
    }
}
 