using System;

class PalindromeChecker
{
    public static void Main(string[] args)
    {
        string input = Console.ReadLine();
        bool result = IsPalindrome(input);
        DisplayResult(input, result);
    }



    // Method to check palindrome
    static bool IsPalindrome(string text)
    {
        if (text == null)
            return false;

        text = text.ToLower();

        int left = 0;
        int right = text.Length - 1;

        while (left < right)
        {
            if (text[left] != text[right])
                return false;

            left++;
            right--;
        }

        return true;
    }

    // Method to display result
    static void DisplayResult(string text, bool isPalindrome)
    {
        if (isPalindrome)
        {
            Console.WriteLine( text + "is a Palindrome");
        }
        else
        {
            Console.WriteLine( text + "is NOT a Palindrome");
        }
    }
}
