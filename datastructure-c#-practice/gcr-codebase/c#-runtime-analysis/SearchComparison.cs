using System;

class SearchComparison
{
    static void Main()
    {
        int n = 1_000_000;
        int[] data = new int[n];

        for (int i = 0; i < n; i++)
            data[i] = i;

        int target = n - 1;
        Stopwatch sw = new Stopwatch();

        // Linear Search
        sw.Start();
        LinearSearch(data, target);
        sw.Stop();
        Console.WriteLine("Linear Search Time: " + sw.ElapsedMilliseconds + " ms");

        // Binary Search
        sw.Restart();
        BinarySearch(data, target);
        sw.Stop();
        Console.WriteLine("Binary Search Time: " + sw.ElapsedMilliseconds + " ms");
    }

    static int LinearSearch(int[] arr, int target)
    {
        for (int i = 0; i < arr.Length; i++)
            if (arr[i] == target)
                return i;
        return -1;
    }

    static int BinarySearch(int[] arr, int target)
    {
        int low = 0, high = arr.Length - 1;
        while (low <= high)
        {
            int mid = (low + high) / 2;
            if (arr[mid] == target) return mid;
            if (arr[mid] < target) low = mid + 1;
            else high = mid - 1;
        }
        return -1;
    }
}
