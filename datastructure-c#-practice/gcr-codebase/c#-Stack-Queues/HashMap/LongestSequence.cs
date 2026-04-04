using System;

class LongestConsecutive
{
    static bool Contains(int[] arr, int n, int key)
    {
        for (int i = 0; i < n; i++)
            if (arr[i] == key)
                return true;
        return false;
    }

    static void Main()
    {
        int[] arr = { 100, 4, 200, 1, 3, 2 };
        int n = arr.Length;
        int longest = 0;

        for (int i = 0; i < n; i++)
        {
            int current = arr[i];
            int count = 1;

            while (Contains(arr, n, current + 1))
            {
                current++;
                count++;
            }

            if (count > longest)
                longest = count;
        }

        Console.WriteLine(longest);
    }
}
