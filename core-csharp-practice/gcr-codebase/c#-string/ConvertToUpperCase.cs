using System;

class ConvertToUpperCase
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the text:");
        string str = Console.ReadLine();

        string cUpper = ConvertUsingAscii(str);
        string builtInUpper = str.ToUpper();

        Console.WriteLine("\nCustom Uppercase Result: " + cUpper);
        Console.WriteLine("Built-in ToUpper Result: " + builtInUpper);
    }

    static string ConvertUsingAscii(string text)
    {
        char[] chars = text.ToCharArray();

        for (int i = 0; i < chars.Length; i++)
        {
            // Check if character is lowercase (a–z)
            if (chars[i] >= 'a' && chars[i] <= 'z')
            {
                chars[i] = (char)(chars[i] - 32);
            }
        }

        return new string(chars);
    }
}
