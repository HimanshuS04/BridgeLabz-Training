using System;
class SpringSeason
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter month number : ");
        int month = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter Date : ");
        int date = int.Parse(Console.ReadLine());

        bool isSpring = IsSpringSeason(month, date);
        if (isSpring)
        {
            Console.WriteLine("It's Spring Season.");
        }
        else
        {
            Console.WriteLine("It's not Spring Season.");
        }
    }

    static bool IsSpringSeason(int month, int date)
    {
        if((month == 3 && date >= 20 || month == 4 || month == 5) || (month == 6 && date <= 20))
        {
            return true;
        }
        return false;
    }
}