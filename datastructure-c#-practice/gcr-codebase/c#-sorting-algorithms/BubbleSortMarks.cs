using System;

class BubbleSortMarks
{
    static void Main()
    {
        int[] marks = { 45, 78, 12, 89, 66 };
        int n = marks.Length;

        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (marks[j] > marks[j + 1])
                {
                    int temp = marks[j];
                    marks[j] = marks[j + 1];
                    marks[j + 1] = temp;
                }
            }
        }

        for (int i = 0; i < n; i++)
            Console.Write(marks[i] + " ");
    }
}
