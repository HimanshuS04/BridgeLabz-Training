using System;
class ArgumentOutOfRangeExceptions
{
    static void Main(string[] args)
    {
        ArgumentException();
    }
    static void ArgumentException()
    {
        string str = "Hello, World!";
        try
        {
            string substr = str.Substring(5, 20); // Invalid length
            Console.WriteLine("Substring: " + substr);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine("Exception caught: " + ex.Message);
        }
    }
}