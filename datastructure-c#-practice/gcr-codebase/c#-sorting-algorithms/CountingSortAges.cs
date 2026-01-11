using System;

class CountingSortAges
{
    static void Main()
    {
        int[] ages = { 12, 15, 10, 18, 14, 12 };
        int min = 10, max = 18;

        int[] count = new int[max - min + 1];

        for (int i = 0; i < ages.Length; i++)
            count[ages[i] - min]++;

        int index = 0;
        for (int i = 0; i < count.Length; i++)
        {
            while (count[i]-- > 0)
                ages[index++] = i + min;
        }

        for (int i = 0; i < ages.Length; i++)
            Console.Write(ages[i] + " ");
    }
}
