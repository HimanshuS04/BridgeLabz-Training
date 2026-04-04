using System;
class Factor
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter a number: ");
        int n = int.Parse(Console.ReadLine());

        int[] factors = FindFactors(n);

        int sum = FindSum(factors);
        Console.WriteLine("Sum of factors of " + n + " is: " + sum);

        int product = FindProduct(factors);
        Console.WriteLine("Product of factors of " + n + " is: " + product);

        double squareSum = FindSquareSum(factors);
        Console.WriteLine("Square Sum of factors of " + n + " is: " + squareSum);

    }
    static double FindSquareSum(int[] factors)
    {
        double squareSum = 0;
        foreach (int factor in factors)
        {
            squareSum += Math.Pow(factor, 2);

        }
        return squareSum;
    }

    static int FindProduct(int[] factors)
    {
        int product = 1;
        foreach(int factor in factors)
        {
            product *= factor;

        }
        return product;
    }

    static int FindSum(int[] factors)
    {
        int sum = 0;
        foreach (int factor in factors)
        {
            sum += factor;
        }
        return sum;
    }
    static int[] FindFactors(int n)
    {
        int count = 0;
        for (int i = 1; i <= n; i++)
        {
            if (n % i == 0)
            {
                count++;
            }
        }

        int[] factors = new int[count];
        int idx = 0;
        for (int i = 1; i <= n; i++)
        {
            if (n % i == 0)
            {
                factors[idx] = i;
                idx++;
            }
        }
        return factors;
    }
}