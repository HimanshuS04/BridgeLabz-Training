using System;

class FootballTeamHeight
{
    static void Main(string[] args)
    {
        int[] height = new int[11];
        Random random = new Random();

        // Generate random height between 150 and 250 cm
        for (int i = 0; i < height.Length; i++)
        {
            height[i] = random.Next(150, 251);
        }

        Console.WriteLine("Heights of football players (in cm):");
        foreach (int h in height)
        {
            Console.WriteLine(h);
        }

        int sum = FindSum(height);
        double mean = FindMean(height);
        int shortest = FindShortest(height);
        int tallest = FindTallest(height);

        Console.WriteLine("\nResults:");
        Console.WriteLine("Sum of height = " + sum);
        Console.WriteLine("Mean height = " + mean);
        Console.WriteLine("Shortest height = " + shortest);
        Console.WriteLine("Tallest height = " + tallest);
    }

    // Method to find sum of height
    static int FindSum(int[] height)
    {
        int sum = 0;
        foreach (int h in height)
        {
            sum += h;
        }
        return sum;
    }

    // Method to find mean height
    static double FindMean(int[] height)
    {
        int sum = FindSum(height);
        return (double)sum / height.Length;
    }

    // e. Method to find shortest height
    static int FindShortest(int[] height)
    {
        int min = height[0];
        foreach (int h in height)
        {
            min = Math.Min(min, h);
        }
        return min;
    }

    // Method to find tallest height
    static int FindTallest(int[] height)
    {
        int max = height[0];
        foreach (int h in height)
        {
            max = Math.Max(max, h);
        }
        return max;
    }
}
