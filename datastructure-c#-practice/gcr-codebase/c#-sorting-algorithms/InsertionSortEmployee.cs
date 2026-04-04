using System;

class InsertionSortEmployee
{
    static void Main()
    {
        int[] empIds = { 105, 101, 109, 102, 108 };
        int n = empIds.Length;

        for (int i = 1; i < n; i++)
        {
            int key = empIds[i];
            int j = i - 1;

            while (j >= 0 && empIds[j] > key)
            {
                empIds[j + 1] = empIds[j];
                j--;
            }
            empIds[j + 1] = key;
        }

        for (int i = 0; i < n; i++)
            Console.Write(empIds[i] + " ");
    }
}
