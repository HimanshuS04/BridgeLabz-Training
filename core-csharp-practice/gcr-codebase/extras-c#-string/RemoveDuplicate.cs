using System;
class RemoveDuplicate
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter a string: ");
        string str = Console.ReadLine();

        string result = RemoveDuplicates(str);
        Console.WriteLine("String after removing duplicates: " + result);
    }

    public static string RemoveDuplicates(string str)
    {
        string result = "";
        for (int i = 0; i < str.Length; i++)
        {
            if (!result.Contains(str[i]))
            {
                result += str[i];
            }
        }
        return result;
    }
}