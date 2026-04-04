using System;
class ReverseStr
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter a string: ");
        string str = Console.ReadLine();

        string reverse = ReverseString(str);
        Console.WriteLine("Reversed string: " + reverse);
    }

    public static string ReverseString(string str)
    {
        string reversed = "";
        for (int i = str.Length - 1; i >= 0; i--)
        {
            reversed += str[i];
        }
        return reversed;
    }
}