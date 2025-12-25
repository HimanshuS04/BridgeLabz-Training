using System;
class LargestSmallest
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter first number ");
        int n1 = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter second number ");
        int n2 = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter third number ");
        int n3 = int.Parse(Console.ReadLine());
        

        int[] result = FindSmallestLargest(n1, n2, n3);

        for (int i = 0; i < result.Length; i++)
        {
            if (i == 0)
            {
                Console.WriteLine("Smallest number :" + result[i]);
            }
            else
            {
                Console.WriteLine("Largest number : " + result[i]);
            }
        }
    }

    static int[] FindSmallestLargest(int n1, int n2, int n3)
    {
        int largest = n1;
        if (n2 > largest)
        {
            largest = n2;
        }
        if (n3 > largest)
        {
            largest = n3;
        }

        int smallest = n1;
        if (n2 < smallest)
        {
            smallest = n2;
        }
        if (n3 < smallest)
        {
            smallest = n3;
        }

        return new int[] { smallest, largest };
    }
}