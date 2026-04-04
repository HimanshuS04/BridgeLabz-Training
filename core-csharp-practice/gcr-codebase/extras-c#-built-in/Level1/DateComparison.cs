using System;

class DateComparison
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter first date (yyyy-MM-dd): ");
        DateTime date1 = Convert.ToDateTime(Console.ReadLine());

        Console.WriteLine("Enter second date (yyyy-MM-dd): ");
        DateTime date2 = Convert.ToDateTime(Console.ReadLine());

        int result = DateTime.Compare(date1, date2);

        if (result < 0)
        {
            Console.WriteLine("First date is BEFORE the second date.");
        }
        else if (result > 0)
        {
            Console.WriteLine("First date is AFTER the second date.");
        }
        else
        {
            Console.WriteLine("Both dates are the SAME.");
        }
    }
}
