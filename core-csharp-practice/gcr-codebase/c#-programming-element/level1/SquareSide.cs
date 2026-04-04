using System;

class SquareSide
{
    static void Main(string[] args)
    {
        double perimeter;

        // Input
        perimeter = Convert.ToDouble(Console.ReadLine());

        // Calculate side
        double side = perimeter / 4;

        // Output
        Console.WriteLine("The length of the side is " + side + " whose perimeter is " + perimeter);
    }
}
