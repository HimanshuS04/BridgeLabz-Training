using System;

class HeapSortSalary
{
    static void Heapify(int[] arr, int n, int i)
    {
        int largest = i;
        int l = 2 * i + 1;
        int r = 2 * i + 2;

        if (l < n && arr[l] > arr[largest])
            largest = l;

        if (r < n && arr[r] > arr[largest])
            largest = r;

        if (largest != i)
        {
            int temp = arr[i];
            arr[i] = arr[largest];
            arr[largest] = temp;

            Heapify(arr, n, largest);
        }
    }

    static void Main()
    {
        int[] salary = { 50000, 30000, 70000, 40000 };
        int n = salary.Length;

        for (int i = n / 2 - 1; i >= 0; i--)
            Heapify(salary, n, i);

        for (int i = n - 1; i > 0; i--)
        {
            int temp = salary[0];
            salary[0] = salary[i];
            salary[i] = temp;

            Heapify(salary, i, 0);
        }

        for (int i = 0; i < n; i++)
            Console.Write(salary[i] + " ");
    }
}
