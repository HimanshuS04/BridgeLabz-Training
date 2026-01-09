using System;

class SlidingWindow
{
    static void Main()
    {
        int[] arr = { 1, 3, -1, -3, 5, 3, 6, 7 };
        int k = 3;

        int[] dq = new int[arr.Length];
        int front = 0, rear = -1;

        for (int i = 0; i < arr.Length; i++)
        {
            if (front <= rear && dq[front] <= i - k)
                front++;

            while (front <= rear && arr[dq[rear]] <= arr[i])
                rear--;

            dq[++rear] = i;

            if (i >= k - 1)
                Console.Write(arr[dq[front]] + " ");
        }
    }
}
