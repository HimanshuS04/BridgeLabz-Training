using System;

class DateFormatting
{
    static void Main(string[] args)
    {
        DateTime todayDate = DateTime.Now;

        Console.WriteLine("Current Date in Different Formats:\n");

        Console.WriteLine("dd/MM/yyyy      : " + todayDate.ToString("dd/MM/yyyy"));
        Console.WriteLine("yyyy-MM-dd      : " + todayDate.ToString("yyyy-MM-dd"));
        Console.WriteLine("EEE, MMM dd, yyyy : " + todayDate.ToString("ddd, MMM dd, yyyy"));
    }
}
