using System;

class FactorsNumber
{
    static void Main(string[] args)
    {
        int number = int.Parse(Console.ReadLine());

        int maxFactor = 10;
        int[] factors = new int[maxFactor];
        int index = 0;

        // Find factors
        for (int i = 1; i <= number; i++)
        {
            if (number % i == 0)
            {
                // If array is full, increase its size
                if (index == maxFactor)
                {
                    maxFactor = maxFactor * 2;
                    int[] temp = new int[maxFactor];

                    // Copy old elements to new array
                    for (int j = 0; j < factors.Length; j++)
                    {
                        temp[j] = factors[j];
                    }

                    factors = temp;
                }
                factors[index] = i;
                index++;
            }
        }

        Console.WriteLine($"Factors of {number} are:");
        for (int i = 0; i < index; i++)
        {
            Console.Write(factors[i] + " ");
        }
    }
}
