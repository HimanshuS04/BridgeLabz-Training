using System;

class FirstNegativeNumber
{
    static void Main()
    {
        int[] arr = { 5, 3, 0, -2, 9, -7 };

        int index = -1;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] < 0)
            {
                index = i;
                break;
            }
        }

        Console.WriteLine("First Negative Number Index: " + index);
    }
}
