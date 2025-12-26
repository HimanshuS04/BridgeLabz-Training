using System;

class ConvertToLowercase
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the text:");
        string str = Console.ReadLine();

        string cLower = ConvertUsingAscii(str);
        string builtInLower = str.ToLower();

        Console.WriteLine("\nCustom Lowercase Result: " + cLower);
        Console.WriteLine("Built-in ToLower Result: " + builtInLower);
    }

    static string ConvertUsingAscii(string text)
    {
        char[] chars = text.ToCharArray();

        for (int i = 0; i < chars.Length; i++)
        {
            // Check if character is uppercase (A–Z)
            if (chars[i] >= 'A' && chars[i] <= 'Z')
            {
                chars[i] = (char)(chars[i] + 32);
            }
        }

        return new string(chars);
    }
}
