using System;

class PairSum
{
    static void Main()
    {
        int[] arr = { 8, 4, 7, 3 };
        int target = 11;

        bool found = false;

        for (int i = 0; i < arr.Length; i++)
            for (int j = i + 1; j < arr.Length; j++)
                if (arr[i] + arr[j] == target)
                    found = true;

        Console.WriteLine(found);
    }
}
