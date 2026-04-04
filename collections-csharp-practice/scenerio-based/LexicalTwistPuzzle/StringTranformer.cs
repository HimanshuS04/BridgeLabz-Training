using System;

class StringTransformer
{
    public static bool IsReverse(string first, string second)
    {
        string reversed = Reverse(first);
        return string.Equals(reversed, second, StringComparison.OrdinalIgnoreCase);
    }

    public static string TransformReversed(string word)
    {
        string reversed = Reverse(word).ToLower();
        return ReplaceVowels(reversed);
    }

    private static string Reverse(string input)
    {
        char[] arr = input.ToCharArray();
        Array.Reverse(arr);
        return new string(arr);
    }

    private static string ReplaceVowels(string input)
    {
        return input
            .Replace("a", "@")
            .Replace("e", "@")
            .Replace("i", "@")
            .Replace("o", "@")
            .Replace("u", "@");
    }
}
