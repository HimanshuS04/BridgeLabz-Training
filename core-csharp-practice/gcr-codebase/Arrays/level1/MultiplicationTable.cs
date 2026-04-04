using System;

class MultiplicationTable
{
    static void Main(string[] args)
    {
        int number = int.Parse(Console.ReadLine());

        if (number < 6 || number > 9)
        {
            Console.WriteLine("enter a number between 6 and 9 ");
            return;
        }

        int[] multiplicationResult = new int[10];

        for (int i = 1; i <= 10; i++)
        {
            multiplicationResult[i - 1] = number * i;
        }

        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine(number + " * " + i + " = " + multiplicationResult[i - 1]);
        }
    }
}
