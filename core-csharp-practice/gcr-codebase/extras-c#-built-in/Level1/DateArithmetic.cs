using System;

class DateArithmetic
{
    static void Main(string[] args)
    {
        Console.Write("Enter a date (yyyy-MM-dd): ");
        string input = Console.ReadLine();

        // Convert string to DateTime (using Convert as you prefer)
        DateTime date = Convert.ToDateTime(input);

        Console.WriteLine("\nOriginal Date : " + date.ToShortDateString());

        // Adding 7 days
        date = date.AddDays(7);
        Console.WriteLine("After adding 7 days  " + date.ToShortDateString());

         // Subtract 3 weeks (3 weeks = 21 days)
        date = date.AddDays(-21);
        Console.WriteLine("After subtracting 3 weeks  " + date.ToShortDateString());

        // Adding  1 month
        date = date.AddMonths(1);
        Console.WriteLine("After adding 1 month  " + date.ToShortDateString());

        // Add 2 years
        date = date.AddYears(2);
        Console.WriteLine("After adding 2 years  " + date.ToShortDateString());

       
    }
}
