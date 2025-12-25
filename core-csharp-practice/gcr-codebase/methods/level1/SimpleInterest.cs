using System;
class SimpleInterest
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter Principal Amount: ");
        double principal = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter Rate of Interest: ");
        double rate = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter Time (in years): ");
        double time = Convert.ToDouble(Console.ReadLine());

        double simpleInterest = SimpleInterestCalculator(principal, rate, time);
        Console.WriteLine("Simple Interest is: " + simpleInterest);
        
    }

    static double SimpleInterestCalculator(double p, double r, double t)
    {
        return (p * r * t) / 100;
    }
}