using System;
class PalindromeString
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter a string: ");
        string str = Console.ReadLine();

        bool isPalindrome = CheckPalindrome(str);
        if (isPalindrome)
        {
            Console.WriteLine($"\"{str}\" is a palindrome.");
        }
        else
        {
            Console.WriteLine($"\"{str}\" is not a palindrome.");
        }
    }

    public static bool CheckPalindrome(string str)
    {
        int left = 0;
        int right = str.Length - 1;

        while (left < right)
        {
            if (str[left] != str[right])
            {
                return false;
            }
            left++;
            right--;
        }
        return true;
    }
}