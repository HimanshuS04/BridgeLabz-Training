using System;

class OddEven
{
    static void Main(string[] args)
    {
        int number = int.Parse(Console.ReadLine());

        if (number <= 0)
        {
            Console.WriteLine("Error: Please enter a natural number greater than 0.");
            return;
        }

        // Create arrays for odd and even numbers
        int[] evenNumbers = new int[number / 2 + 1];
        int[] oddNumbers = new int[number / 2 + 1];
        int eIndex = 0;
        int oIndex = 0;

        // Store odd and even numbers
        for (int i = 1; i <= number; i++)
        {
            if (i % 2 == 0)
            {
                evenNumbers[eIndex] = i;
                eIndex++;
            }
            else
            {
                oddNumbers[oIndex] = i;
                oIndex++;
            }
        }

        // Print odd numbers
        Console.WriteLine("Odd Numbers:");
        for (int i = 0; i < oIndex; i++)
        {
            Console.Write(oddNumbers[i] + " ");
        }

        Console.WriteLine();

        // Print even numbers
        Console.WriteLine("Even Numbers:");
        for (int i = 0; i < eIndex; i++)
        {
            Console.Write(evenNumbers[i] + " ");
        }
    }
}
