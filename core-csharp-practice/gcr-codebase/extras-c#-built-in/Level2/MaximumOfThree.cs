using System;

class MaximumOfThree
{
    public static void Main(string[] args)
    {
        int a = ReadNumber("Enter first num: ");
        int b = ReadNumber("Enter second num: ");
        int c = ReadNumber("Enter third num: ");

        int max = FindMaximum(a, b, c);

        Console.WriteLine("\nMaximum of the three numbers is: " + max);
    }

    static int ReadNumber(string message)
    {
        Console.Write(message);
        return int.Parse(Console.ReadLine());
    }

    // Method to find maximum of three numbers
    static int FindMaximum(int x, int y, int z)
    {
        int max = x;

        if (y > max)
        {
            max = y;
        }

        if (z > max)
        {
            max = z;
        }

        return max;
    }
}
