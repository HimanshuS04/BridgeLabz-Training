using System;

class PrimeNumberChecker
{
    public static void Main(string[] args)
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());

        bool isPrime = IsPrime(number);

        if (isPrime)
        {
            Console.WriteLine(number + " is a Prime Number");
        }
        else
        {
            Console.WriteLine(number + " is NOT a Prime Number");
        }
    }


    static bool IsPrime(int num)
    {

        if (num <= 1)
            return false;


        for (int i = 2; i <= Math.Sqrt(num); i++)
        {
            if (num % i == 0)
                return false;
        }

        return true;
    }
}
