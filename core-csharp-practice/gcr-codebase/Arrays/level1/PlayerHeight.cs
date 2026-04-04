using System;

class PlayerHeight
{
    static void Main(string[] args)
    {
        double[] heights = new double[11];
        double sum = 0;

        Console.WriteLine("Enter the heights of players:");
        for (int i = 0; i < 11; i++)
        {
            heights[i] = double.Parse(Console.ReadLine());
            sum += heights[i];
        }
        double mean = sum / 11;

        Console.WriteLine("Mean height of the football team is: " + mean);
    }
}
