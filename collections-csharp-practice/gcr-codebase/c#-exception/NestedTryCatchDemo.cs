using System;

class NestedTryCatchDemo
{
    static void Main()
    {
        int[] arr = { 10, 20 };

        try
        {
            try
            {
                Console.WriteLine(arr[1] / 0);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Cannot divide by zero!");
            }
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Invalid array index!");
        }
    }
}
