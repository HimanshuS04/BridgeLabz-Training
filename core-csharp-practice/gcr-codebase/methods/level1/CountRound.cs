using System;
class CountRound
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter first side of triangle: ");
        double side1 = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter second side of triangle: ");
        double side2 = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter third side of triangle: ");
        double side3 = double.Parse(Console.ReadLine());

        double rounds = CalculateRound(side1, side2, side3);
        Console.WriteLine("Number of rounds that can be formed: " + rounds);
    }
    static double CalculateRound(double a, double b, double c)
    {
        double perimeter = a + b + c;
        double rounds = 5000 / perimeter;
        return Math.Round(rounds, 2);
    }
}