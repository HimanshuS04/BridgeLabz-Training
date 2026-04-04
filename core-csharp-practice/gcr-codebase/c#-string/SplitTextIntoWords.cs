using System;

class SplitTextIntoWords
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a sentence:");
        string input = Console.ReadLine();

        string[,] result = SplitWordsWithLength(input);

        Console.WriteLine("\nWord\tLength");

        for (int i = 0; i < result.GetLength(0); i++)
        {
            Console.WriteLine(result[i, 0] + "\t" + result[i, 1]);
        }
    }

    // Method to split words and return 2D array
    static string[,] SplitWordsWithLength(string text)
    {
        int wordCount = CountWords(text);

        string[,] result = new string[wordCount, 2];

        string currentWord = "";
        int index = 0;

        foreach (char ch in text)
        {
            if (ch != ' ')
            {
                currentWord += ch;
            }
            else
            {
                if (currentWord != "")
                {
                    result[index, 0] = currentWord;
                    result[index, 1] = GetStringLength(currentWord).ToString();
                    index++;
                    currentWord = "";
                }
            }
        }

        // Add last word
        if (currentWord != "")
        {
            result[index, 0] = currentWord;
            result[index, 1] = GetStringLength(currentWord).ToString();
        }

        return result;
    }

    // Method to count words without Split
    static int CountWords(string text)
    {
        int count = 0;
        bool inWord = false;

        foreach (char ch in text)
        {
            if (ch != ' ' && !inWord)
            {
                count++;
                inWord = true;
            }
            else if (ch == ' ')
            {
                inWord = false;
            }
        }

        return count;
    }

    // Method to calculate string length without Length
    static int GetStringLength(string word)
    {
        int length = 0;
        foreach (char ch in word)
        {
            length++;
        }
        return length;
    }
}
