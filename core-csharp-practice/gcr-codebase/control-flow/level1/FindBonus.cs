using System;

class FindBonus
{
    public static void Main(string[] args)
    {

        double salary = Convert.ToDouble(Console.ReadLine());


        int yearsOfService = Convert.ToInt32(Console.ReadLine());

        if (yearsOfService > 5)
        {
            double bonus = salary * 0.05;
            Console.WriteLine("Bonus Amount: " + bonus);
        }
        else
        {
            Console.WriteLine("No bonus applicable");
        }
    }
}