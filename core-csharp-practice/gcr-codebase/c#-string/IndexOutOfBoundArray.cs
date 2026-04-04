using System;

class IndexOutOfBoundArray
{
    static void Main(string[] args)
    {
        IndexOutOfRangeExceptions();
    }

    static void IndexOutOfRangeExceptions()
    {
        int[] numbers = { 10, 20, 30, 40, 50 };

        try
        {
            // Invalid index (array length is 5, last index is 4)
            int value = numbers[10];
            Console.WriteLine("Value at index 10: " + value);
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine("Error: Attempted to access an index outside the array bounds."+ex.Message);
        }
    }
}
