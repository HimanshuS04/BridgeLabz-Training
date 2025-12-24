using System;
class Largest
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the number: ");
        int n = Convert.ToInt32(Console.ReadLine());
        int maxDigit = 10;
        int[] digits = new int[maxDigit];
        int idx = 0;
        while (n > 0)
        {
            if (idx == maxDigit)
            {
                break;
            }
            digits[idx] = n % 10;
            n = n / 10;
            idx++;
        }
        int largest = 0;
        int secondLargest = 0;
        for (int i = 0; i < idx; i++)
        {
            if(digits[i] > largest)
            {
                secondLargest = largest;
                largest = digits[i];
            }else if(digits[i] > secondLargest && digits[i] != largest)
            {
                secondLargest = digits[i];
            }
        }
        Console.WriteLine("Largest Digit: " + largest);
        Console.WriteLine("Second Largest Digit: " + secondLargest);
    }
}