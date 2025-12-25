using System;

class Calendar
{
    //  Method to get month name
    public static string GetMonth(int month)
    {
        string[] months = { "January", "February", "March", "April", "May", "June",
                            "July", "August", "September", "October", "November", "December" };
        if (month < 1 || month > 12) return "Invalid Month";
        return months[month - 1];
    }

    //  Leap year check
    public static bool IsLeapYear(int year)
    {
        return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
    }

    //  Get number of days in month
    public static int GetNumDays(int month, int year)
    {
        int[] daysInMonth = { 31, 28, 31, 30, 31, 30, 
                              31, 31, 30, 31, 30, 31 };
        if (month == 2 && IsLeapYear(year)) return 29;
        return daysInMonth[month - 1];
    }

    //  Get first day of the month using Gregorian algorithm
    public static int FirstDayMonth(int month, int year)
    {
        int y0 = year - (14 - month) / 12;
        int x = y0 + y0 / 4 - y0 / 100 + y0 / 400;
        int m0 = month + 12 * ((14 - month) / 12) - 2;
        int d0 = (1 + x + (31 * m0) / 12) % 7; // 1st day of the month
        return d0;
    }

    // f. Display the calendar
    public static void DisplayCalendar(int month, int year)
    {
        string monthName = GetMonth(month);
        int daysInMonth = GetNumDays(month, year);
        int firstDay = FirstDayMonth(month, year);

        Console.WriteLine("\n     " + monthName + " " + year);
        Console.WriteLine("Su Mo Tu We Th Fr Sa");

        //  First loop for indentation
        for (int i = 0; i < firstDay; i++)
        {
            Console.Write("   ");
        }

        //  Second loop to print the days
        for (int day = 1; day <= daysInMonth; day++)
        {
            Console.Write(day.ToString().PadLeft(2) + " ");
            if ((firstDay + day) % 7 == 0)
                Console.WriteLine();
        }
        Console.WriteLine();
    }

    static void Main(string[] args)
    {
        Console.Write("Enter month (1-12): ");
        int month = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter year: ");
        int year = Convert.ToInt32(Console.ReadLine());

        DisplayCalendar(month, year);
    }
}
