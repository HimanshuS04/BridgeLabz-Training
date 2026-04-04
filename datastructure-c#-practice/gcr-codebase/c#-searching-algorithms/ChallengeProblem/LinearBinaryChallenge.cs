using System;

class LinearBinaryChallenge
{
    static void Main()
    {
        int[] arr = { 3, 4, -1, 1 };

        // Linear Search – First Missing Positive
        int n = arr.Length;
        bool[] present = new bool[n + 1];

        for (int i = 0; i < n; i++)
        {
            if (arr[i] > 0 && arr[i] <= n)
                present[arr[i]] = true;
        }

        int missing = n + 1;
        for (int i = 1; i <= n; i++)
        {
            if (!present[i])
            {
                missing = i;
                break;
            }
        }

        Console.WriteLine("First Missing Positive: " + missing);

        // Binary Search
        Array.Sort(arr);
        int target = 4;
        int low = 0, high = arr.Length - 1, index = -1;

        while (low <= high)
        {
            int mid = (low + high) / 2;
            if (arr[mid] == target)
            {
                index = mid;
                break;
            }
            else if (arr[mid] < target)
                low = mid + 1;
            else
                high = mid - 1;
        }

        Console.WriteLine("Target Index: " + index);
    }
}
