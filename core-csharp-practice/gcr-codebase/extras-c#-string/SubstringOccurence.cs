using System;
class SubstringOccurence
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the main string: ");
        string mainStr = Console.ReadLine();

        Console.WriteLine("Enter the substring to search: ");
        string subStr = Console.ReadLine();

        int count = CheckSubstringOcuurence(mainStr, subStr);
        Console.WriteLine($"The substring \"{subStr}\" occurs {count} times in the main string.");
    }

    public static int CheckSubstringOcuurence(string mainStr, string subStr)
    {
        int count = 0;
        int index = 0;

        while ((index = mainStr.IndexOf(subStr, index)) != -1)
        {
            count++;
            index += subStr.Length;
        }

        return count;
    }
}