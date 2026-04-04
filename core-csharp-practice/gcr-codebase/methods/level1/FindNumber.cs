using System;
class FindNumber
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the number : ");
        int n = int.Parse(Console.ReadLine());

        int result = Find(n);
        Console.WriteLine(result);
    }

    static int Find(int n)
    {
        if (n == 0)
        {
            return 0;
        }else if (n > 0)
        {
            return 1;
        }
        else
        {
            return -1;
        }
    }
}