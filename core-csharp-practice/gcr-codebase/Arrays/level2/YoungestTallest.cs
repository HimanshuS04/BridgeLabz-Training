using System;
class YoungestTallest
{
    static void Main(string[] args)
    {
        int[] ages = new int[3];
        int[] heights = new int[3];

        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("Enter Age of Person " + (i + 1) + ": ");
            ages[i] = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Height (in cm) of Person " + (i + 1) + ": ");
            heights[i] = Convert.ToInt32(Console.ReadLine());
        }
        for (int i = 0; i < 3; i++)
        {
            if(ages[i] == Math.Min(Math.Min(ages[0], ages[1]), ages[2]))
            {
                Console.WriteLine("Youngest Person is Person " + (i + 1));
            }
            if(heights[i] == Math.Max(Math.Max(heights[0], heights[1]), heights[2]))
            {
                Console.WriteLine("Tallest Person is Person " + (i + 1));
            }
        }
    }
}