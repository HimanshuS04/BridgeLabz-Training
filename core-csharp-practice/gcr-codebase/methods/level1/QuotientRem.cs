using System;
class QuotientRem
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the dividend: ");
        int dividend = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the divisor: ");
        int divisor = int.Parse(Console.ReadLine());

        int[] result = QuotientRemender(dividend, divisor);
        Console.WriteLine("Quotient: " + result[0]);
        Console.WriteLine("Remainder: " + result[1]);
    }
    static int[] QuotientRemender(int dividend, int divisor)
    {
        int quotient = dividend / divisor;
        int remainder = dividend % divisor;
        int[] result = { quotient, remainder };
        return result;
        
    }
}