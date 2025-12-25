using System;
class SumOfNNumber
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter a positive number: ");
        int n = int.Parse(Console.ReadLine());

        if (n < 0)
        {
            Console.WriteLine("Please enter a positive integer.");
            return;
        }

        int SumRecursion = CalculateSumRecursion(n);
        int SumFormula = CalculateSumFormula(n);

        Console.WriteLine("Sum of first " + n + " natural numbers using recursion is: " + SumRecursion);
        Console.WriteLine("Sum of first " + n + " natural numbers using formula is: " + SumFormula);

        if(SumRecursion == SumFormula)
        {
            Console.WriteLine("Both methods give the same result.");
        }
        else
        {
            Console.WriteLine("There is a discrepancy between the two methods.");
        }
    }

    static int CalculateSumRecursion(int n)
    {
        if (n == 1)
            return 1;
        return n + CalculateSumRecursion(n - 1);
    }
    static int CalculateSumFormula(int n)
    {
        return n * (n + 1) / 2;
    }
}