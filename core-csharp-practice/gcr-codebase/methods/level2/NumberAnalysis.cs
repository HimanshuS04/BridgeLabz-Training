using System;

class NumberAnalysis
{
    static void Main(string[] args)
    {
        int[] numm = new int[5];


        for (int i = 0; i < numm.Length; i++)
        {
            Console.Write("Enter number " + (i + 1) + ": ");
            numm[i] = Convert.ToInt32(Console.ReadLine());
        }

        Console.WriteLine("\nNumber Analysis:");
        for (int i = 0; i < numm.Length; i++)
        {
            if (IsPositive(numm[i]))
            {
                Console.Write(numm[i] + " is Positive and ");

                if (IsEven(numm[i]))
                    Console.WriteLine("Even");
                else
                    Console.WriteLine("Odd");
            }
            else
            {
                Console.WriteLine(numm[i] + " is Negative");
            }
        }


        int result = Compare(numm[0], numm[numm.Length - 1]);

        Console.WriteLine("\nComparison of first and last elements:");
        if (result == 1)
            Console.WriteLine("First element is greater than last element");
        else if (result == 0)
            Console.WriteLine("First element is equal to last element");
        else
            Console.WriteLine("First element is less than last element");
    }


    static bool IsPositive(int number)
    {
        return number >= 0;
    }


    static bool IsEven(int number)
    {
        return number % 2 == 0;
    }


    static int Compare(int num1, int num2)
    {
        if (num1 > num2)
            return 1;
        else if (num1 == num2)
            return 0;
        else
            return -1;
    }
}
