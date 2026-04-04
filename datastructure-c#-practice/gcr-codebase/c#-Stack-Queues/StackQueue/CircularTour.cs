using System;

class CircularTour
{
    static void Main()
    {
        int[] petrol = { 6, 3, 7 };
        int[] dist = { 4, 6, 3 };

        int balance = 0, deficit = 0, start = 0;

        for (int i = 0; i < petrol.Length; i++)
        {
            balance += petrol[i] - dist[i];
            if (balance < 0)
            {
                deficit += balance;
                start = i + 1;
                balance = 0;
            }
        }

        Console.WriteLine((balance + deficit >= 0) ? start : -1);
    }
}
