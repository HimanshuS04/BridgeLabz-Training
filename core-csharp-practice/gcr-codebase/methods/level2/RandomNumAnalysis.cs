using System;

class RandomNumAnalysis
{
    static void Main(string[] args)
    {
        int size = 5;

        int[] numbers = GenrateArray(size);

        Console.WriteLine("Generated 4-digit random numbers:");
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }

        double[] result = FindAverageMinMax(numbers);

        Console.WriteLine("\nResults:");
        Console.WriteLine("Average = " + result[0]);
        Console.WriteLine("Minimum = " + result[1]);
        Console.WriteLine("Maximum = " + result[2]);
    }

    // a. Generate array of 4-digit random numbers
    public static int[] GenrateArray(int size)
    {
        int[] numbers = new int[size];
        Random rand = new Random();

        for (int i = 0; i < size; i++)
        {
            // 4-digit numbers range from 1000 to 9999
            numbers[i] = rand.Next(1000, 10000);
        }

        return numbers;
    }

    // b. Find average, minimum, and maximum
    public static double[] FindAverageMinMax(int[] numbers)
    {
        int min = numbers[0];
        int max = numbers[0];
        int sum = 0;

        foreach (int num in numbers)
        {
            sum += num;
            min = Math.Min(min, num);
            max = Math.Max(max, num);
        }

        double average = (double)sum / numbers.Length;

        return new double[] { average, min, max };
    }
}
