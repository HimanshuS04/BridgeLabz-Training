using System;

class SelectionSortScores
{
    static void Main()
    {
        int[] scores = { 78, 45, 90, 60,100 };
        int n = scores.Length;

        for (int i = 0; i < n - 1; i++)
        {
            int min = i;

            for (int j = i + 1; j < n; j++)
                if (scores[j] < scores[min])
                    min = j;

            int temp = scores[min];
            scores[min] = scores[i];
            scores[i] = temp;
        }

        for (int i = 0; i < n; i++)
            Console.Write(scores[i] + " ");
    }
}
