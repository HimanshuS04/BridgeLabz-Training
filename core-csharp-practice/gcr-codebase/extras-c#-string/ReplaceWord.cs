using System;

class ReplaceWord
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter a sentence:");
        string sentence = Console.ReadLine();

        Console.WriteLine("Enter word to replace:");
        string oldWord = Console.ReadLine();

        Console.WriteLine("Enter new word:");
        string newWord = Console.ReadLine();

        string result = Replace(sentence, oldWord, newWord);
        Console.WriteLine("Updated sentence:");
        Console.WriteLine(result);
    }

    public static string Replace(string sentence, string oldWord, string newWord)
    {
        string result = "";
        int i = 0;

        while (i < sentence.Length)
        {
            // Check if oldWord matches at position i
            if (i + oldWord.Length <= sentence.Length &&
                sentence.Substring(i, oldWord.Length).Equals(oldWord))
            {
                result += newWord;
                i += oldWord.Length;
            }
            else
            {
                result += sentence[i];
                i++;
            }
        }

        return result;
    }
}
