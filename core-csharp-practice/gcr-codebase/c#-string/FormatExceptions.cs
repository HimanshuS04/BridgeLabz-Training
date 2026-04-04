using System;

class FormatExceptions
{
    static void Main(string[] args)
    {
        DemonstrateFormatException();
    }

    static void DemonstrateFormatException()
    {
        Console.WriteLine("Enter a number:");
        string input = Console.ReadLine();

        try
        {
            int number = int.Parse(input); // Throws FormatException
            Console.WriteLine("Converted number: " + number);
        }
        catch (FormatException ex)
        {
            Console.WriteLine("Invalid input. Please enter a numeric value."+ex.Message);
        }
    }
}
