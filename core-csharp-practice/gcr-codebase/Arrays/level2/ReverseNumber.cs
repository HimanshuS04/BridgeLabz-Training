using System;
class ReverseNumber
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the number: ");
        int n = Convert.ToInt32(Console.ReadLine());
        int temp = n;
        int count = 0;
        while (temp > 0)
        {
            count++;
            temp = temp / 10;
        }
        int[] digits = new int[count];
        for (int i = 0; i < count; i++)
        {
            digits[i] = n % 10;
            n = n / 10;
        }
        int[] reversedDigits = new int[count];
        for (int i = 0; i < count; i++)
        {
            reversedDigits[i] = digits[count - 1 - i];
        }
        for (int i = 0; i < count; i++)
        {
            Console.Write(reversedDigits[i]);
        }
    }
}