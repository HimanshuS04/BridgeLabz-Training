using System;

class StockSpan
{
    static void Main()
    {
        int[] price = { 100, 80, 60, 70, 60, 75, 85 };
        int n = price.Length;
        int[] span = new int[n];
        int[] st = new int[n];
        int top = -1;

        for (int i = 0; i < n; i++)
        {
            while (top != -1 && price[st[top]] <= price[i])
                top--;

            span[i] = (top == -1) ? i + 1 : i - st[top];
            st[++top] = i;
        }

        for (int i = 0; i < n; i++)
            Console.Write(span[i] + " ");
    }
}
