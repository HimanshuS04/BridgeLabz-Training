using System;

class GcdLcm
{
    public static void Main(string[] args)
    {
        int a = ReadInt("Enter first integer: ");
        int b = ReadInt("Enter second integer: ");

        int gcd = ComputeGcd(a, b);
        long lcm = ComputeLcm(a, b, gcd); // long to avoid overflow for product

        DisplayResult(a, b, gcd, lcm);
    }

    // Read integer using Convert
    static int ReadInt(string prompt)
    {
        Console.Write(prompt);
        return int.Parse(Console.ReadLine());
    }

    // Compute GCD using the iterative Euclidean algorithm
    static int ComputeGcd(int x, int y)
    {
        x = Math.Abs(x);
        y = Math.Abs(y);

        if (x == 0) return y;
        if (y == 0) return x;

        while (y != 0)
        {
            int temp = x % y;
            x = y;
            y = temp;
        }
        return x;
    }

    // Compute LCM using formula |a * b| / gcd. Returns 0 if either input is 0.
    static long ComputeLcm(int a, int b, int gcd)
    {
        if (a == 0 || b == 0) return 0;
        // use long to avoid overflow when multiplying ints
        return Math.Abs((long)a * (long)b) / gcd;
    }

    // Display the results
    static void DisplayResult(int a, int b, int gcd, long lcm)
    {
        Console.WriteLine($"\nNumbers: {a} and {b}");
        Console.WriteLine($"GCD: {gcd}");
        Console.WriteLine($"LCM: {lcm}");
    }
}
