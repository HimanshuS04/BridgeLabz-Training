using System;

class CheckNum
{
    static void Main(string[] args)
    {
        int num = int.Parse(Console.ReadLine());

        if (num > 0){
            Console.WriteLine("Positive");
        }
        else if (num < 0)
        {
            Console.WriteLine("Negative");
        }
        else
        {
            Console.WriteLine("Zero");
        }
    }
}
