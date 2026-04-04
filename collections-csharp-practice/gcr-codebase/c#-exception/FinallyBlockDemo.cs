using System;

class FinallyBlockDemo
{
    static void Main()
    {
        try
        {
            int a = 10, b = 0;
            Console.WriteLine(a / b);
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Divide by zero error");
        }
        finally
        {
            Console.WriteLine("Operation completed");
        }
    }
}
