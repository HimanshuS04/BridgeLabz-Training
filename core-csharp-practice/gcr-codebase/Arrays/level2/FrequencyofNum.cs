using System;
class FrequencyofNum
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter number : ");
        int n = Convert.ToInt32(Console.ReadLine());
        int temp = n;
        int count = 0;
        if (temp == 0)
        {
            count = 1;
        }
        else
        {
            while (temp > 0)
            {
                count++;
                temp /= 10;
            }
        }
        int[] digits = new int[count];
        int idx = 0;
        if (n == 0)
        {
            digits[0] = 0;
            idx = 1;
        }
        else
        {
            while (n > 0)
            {
                digits[idx++] = n % 10;
                n /= 10;
            }
        }
        int[] freq = new int[10];
        for (int i = 0; i < idx; i++)
        {
            freq[digits[i]]++;
        }
        for (int i = 0; i < 10; i++)
        {
            if (freq[i] > 0)
            {
                Console.WriteLine("Frequency of " + i + " is: " + freq[i]);
            }
        }
    }
}