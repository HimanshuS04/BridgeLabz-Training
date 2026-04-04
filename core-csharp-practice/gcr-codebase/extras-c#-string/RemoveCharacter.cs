using System;
class RemoveCharacter
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter a string: ");
        string str = Console.ReadLine();

        Console.WriteLine("Enter the character to remove: ");
        char charToRemove = Console.ReadLine()[0];

        string result = RemoveChar(str, charToRemove);
        Console.WriteLine("String after removing character: " + result);
    }

    public static string RemoveChar(string str, char charToRemove)
    {
        string result = "";
        foreach (char c in str)
        {
            if (c != charToRemove)
            {
                result += c;
            }
        }
        return result;
    }
}