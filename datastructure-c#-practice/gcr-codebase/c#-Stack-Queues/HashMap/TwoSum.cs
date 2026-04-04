using System;

class TwoSum
{
    static void Main()
    {
        int[] arr = { 2, 7, 11, 15 };
        int target = 9;

        for (int i = 0; i < arr.Length; i++)
            for (int j = i + 1; j < arr.Length; j++)
                if (arr[i] + arr[j] == target)
                {
                    Console.WriteLine(i + " " + j);
                    return;
                }
    }
}
