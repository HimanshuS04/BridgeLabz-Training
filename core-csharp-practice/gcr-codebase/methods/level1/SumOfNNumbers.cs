using System;
class SumOfNNumbers
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter a positive integer: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int sum = CalculateSum(n);
        Console.WriteLine("Sum of first " + n + " natural numbers is: " + sum);
    }

    static int CalculateSum(int n)
    {
        return n * (n + 1) / 2;
    }
}