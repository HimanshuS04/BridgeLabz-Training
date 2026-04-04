using System;

class MergeSortBooks
{
    static void Merge(int[] arr, int l, int m, int r)
    {
        int n1 = m - l + 1;
        int n2 = r - m;

        int[] Left = new int[n1];
        int[] Right = new int[n2];

        for (int i = 0; i < n1; i++)
            Left[i] = arr[l + i];
        for (int j = 0; j < n2; j++)
            Right[j] = arr[m + 1 + j];

        int i1 = 0, i2 = 0, k = l;

        while (i1 < n1 && i2 < n2)
        {
            if (Left[i1] <= Right[i2])
                arr[k++] = Left[i1++];
            else
                arr[k++] = Right[i2++];
        }

        while (i1 < n1)
            arr[k++] = Left[i1++];

        while (i2 < n2)
            arr[k++] = Right[i2++];
    }

    static void MergeSort(int[] arr, int l, int r)
    {
        if (l < r)
        {
            int m = (l + r) / 2;
            MergeSort(arr, l, m);
            MergeSort(arr, m + 1, r);
            Merge(arr, l, m, r);
        }
    }

    static void Main()
    {
        int[] prices = { 499, 199, 899, 299 };
        MergeSort(prices, 0, prices.Length - 1);

        for (int i = 0; i < prices.Length; i++)
            Console.Write(prices[i] + " ");
    }
}
