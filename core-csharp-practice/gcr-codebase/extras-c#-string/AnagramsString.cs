using System;
class AnagramsString
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the first string: ");
        string str1 = Console.ReadLine();

        Console.WriteLine("Enter the second string: ");
        string str2 = Console.ReadLine();

        bool IsAnagram = IsAnagram(str1, str2);
        if (IsAnagram)
        {
            Console.WriteLine("The strings are anagrams.");
        }
        else
        {
            Console.WriteLine("The strings are not anagrams.");
        }
    }

    public static bool IsAnagram(string str1, string str2)
    {
        str1 = str1.Replace(" ", "").ToLower();
        str2 = str2.Replace(" ", "").ToLower();

        if (str1.Length != str2.Length)
        {
            return false;
        }

        char[] cArray = str1.ToCharArray();
        char[] cArray1 = str2.ToCharArray();

        Array.Sort(cArray);
        Array.Sort(cArray1);

        for (int i = 0; i < cArray.Length; i++)
        {
            if (cArray[i] != cArray1[i])
            {
                return false;
            }
        }
        return true;
    }
}