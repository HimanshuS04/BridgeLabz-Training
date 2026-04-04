using System;


class SortingComparison
{
    static void Main()
    {
        int size = 10_000;
        int[] arr1 = Generate(size);
        int[] arr2 = (int[])arr1.Clone();
        int[] arr3 = (int[])arr1.Clone();

        Stopwatch sw = new Stopwatch();

        sw.Start();
        BubbleSort(arr1);
        sw.Stop();
        Console.WriteLine("Bubble Sort Time: " + sw.ElapsedMilliseconds + " ms");

        sw.Restart();
        MergeSort(arr2, 0, arr2.Length - 1);
        sw.Stop();
        Console.WriteLine("Merge Sort Time: " + sw.ElapsedMilliseconds + " ms");

        sw.Restart();
        QuickSort(arr3, 0, arr3.Length - 1);
        sw.Stop();
        Console.WriteLine("Quick Sort Time: " + sw.ElapsedMilliseconds + " ms");
    }

    static int[] Generate(int n)
    {
        Random r = new Random();
        int[] arr = new int[n];
        for (int i = 0; i < n; i++)
            arr[i] = r.Next(1, n);
        return arr;
    }

    static void BubbleSort(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
            for (int j = 0; j < arr.Length - i - 1; j++)
                if (arr[j] > arr[j + 1])
                {
                    int t = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = t;
                }
    }

    static void MergeSort(int[] arr, int l, int r)
    {
        if (l >= r) return;
        int m = (l + r) / 2;
        MergeSort(arr, l, m);
        MergeSort(arr, m + 1, r);
        Merge(arr, l, m, r);
    }

    static void Merge(int[] arr, int l, int m, int r)
    {
        int[] temp = new int[r - l + 1];
        int i = l, j = m + 1, k = 0;

        while (i <= m && j <= r)
            temp[k++] = arr[i] < arr[j] ? arr[i++] : arr[j++];

        while (i <= m) temp[k++] = arr[i++];
        while (j <= r) temp[k++] = arr[j++];

        for (int x = 0; x < temp.Length; x++)
            arr[l + x] = temp[x];
    }

    static void QuickSort(int[] arr, int l, int h)
    {
        if (l >= h) return;
        int p = Partition(arr, l, h);
        QuickSort(arr, l, p - 1);
        QuickSort(arr, p + 1, h);
    }

    static int Partition(int[] arr, int l, int h)
    {
        int pivot = arr[h];
        int i = l - 1;

        for (int j = l; j < h; j++)
            if (arr[j] < pivot)
            {
                i++;
                int t = arr[i];
                arr[i] = arr[j];
                arr[j] = t;
            }

        int temp = arr[i + 1];
        arr[i + 1] = arr[h];
        arr[h] = temp;

        return i + 1;
    }
}
