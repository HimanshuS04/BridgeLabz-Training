using System;
class FindLeapYear
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the year: ");
        int year = Convert.ToInt32(Console.ReadLine());
        
        bool isLeap = IsLeapYear(year);
        if (isLeap)
        {
            Console.WriteLine(year + " is a leap year.");
        }
        else
        {
            Console.WriteLine(year + " is not a leap year.");
        }
    }

    static bool IsLeapYear(int year)
    {
        if (year < 1582)
        {
            Console.WriteLine("Enter a year after 1582.");
            return false;
        }else if ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0))
        {
            return true;
        }
        return false;
    }
}