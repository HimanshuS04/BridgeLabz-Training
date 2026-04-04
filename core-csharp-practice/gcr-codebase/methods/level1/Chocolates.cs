using System;
class Chocolates
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter number of chocolate: ");
        int chocolate = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter number of students: ");
        int students = int.Parse(Console.ReadLine());

        int[] result = CalQuotientRemnder(chocolate, students);
        Console.WriteLine("Number of Chocolate get: " + result[0]);
        Console.WriteLine("Number of chocolate remaining: " + result[1]);
    }
    static int[] CalQuotientRemnder(int dividend, int divisor)
    {
        int quotient = dividend / divisor;
        int remainder = dividend % divisor;
        int[] result = { quotient, remainder };
        return result;
        
    }
}