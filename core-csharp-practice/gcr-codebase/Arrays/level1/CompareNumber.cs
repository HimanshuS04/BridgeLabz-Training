using System;
class CompareNumber
{
    static void Main(string[] args)
    {
        int[] nums= new int[5];
        for(int i = 0; i < nums.Length; i++)
        {
            nums[i]=int.Parse(Console.ReadLine());
        }
        for(int j = 0; j < nums.Length; j++)
        {
            if (nums[j] > 0)
            {
                if (nums[j] % 2 == 0)
                {
                    Console.WriteLine($"{nums[j]} is a even number");
                }
                else
                {
                    Console.WriteLine($"{nums[j]} is a odd number");
                }
            }
            else if (nums[j] < 0)
            {
                Console.WriteLine($"{nums[j]} is a negative number");
            }
            else
            {
                Console.WriteLine($"{nums[j]} is zero");
            }

        }
        int first=nums[0];
        int last=nums[nums.Length-1];
        if (first > last)
        {
            Console.WriteLine("first is greter then last");
        }
        else if (last > first)
        {
            Console.WriteLine("last is greter than first");
        }
        else
        {
            Console.WriteLine("Both are equal");
        }
    }
}