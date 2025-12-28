using System;
class LexicographicallyComparisons
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter first string: ");
        string str1 = Console.ReadLine();

        Console.WriteLine("Enter second string: ");
        string str2 = Console.ReadLine();

        int result = CompareStrings(str1, str2);
        if (result < 0)
        {
            Console.WriteLine($"\"{str1}\" comes before \"{str2}\" in Lexicographical order.");
        }
        else if (result > 0)
        {
            Console.WriteLine($"\"{str1}\" comes after \"{str2}\" in Lexicographical order.");
        }
        else
        {
            Console.WriteLine($"\"{str1}\" is equal to \"{str2}\".");
        }
    }

    public static int CompareStrings(string str1, string str2)
    {
        int minLength = Math.Min(str1.Length, str2.Length);
        for (int i = 0; i < minLength; i++)
        {
            if (str1[i] != str2[i])
            {
                return str1[i] - str2[i];
            }
        }
        return str1.Length - str2.Length;
    }
}