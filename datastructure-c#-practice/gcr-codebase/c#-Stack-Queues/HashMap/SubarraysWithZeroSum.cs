using System;

class ZeroSumSubarray
{
    static void Main()
    {
        int[] arr = { 4, 2, -3, 1, 6 };
        int[] sums = new int[arr.Length];
        int size = 0, sum = 0;
        bool found = false;

        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
            if (sum == 0) { found = true; break; }

            for (int j = 0; j < size; j++)
                if (sums[j] == sum) found = true;

            sums[size++] = sum;
        }

        Console.WriteLine(found);
    }
}
