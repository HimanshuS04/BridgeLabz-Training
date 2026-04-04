using System;
using System.Collections.Generic;

class LexicalAnalyzer
{
    public static void Analyze(string first, string second)
    {
        string combined = (first + second).ToUpper();
        HashSet<char> vowels = new HashSet<char> { 'A', 'E', 'I', 'O', 'U' };

        int vowelCount = 0, consonantCount = 0;

        foreach (char c in combined)
        {
            if (vowels.Contains(c))
                vowelCount++;
            else if (char.IsLetter(c))
                consonantCount++;
        }

        if (vowelCount > consonantCount)
        {
            PrintFirstTwo(combined, vowels, true);
        }
        else if (consonantCount > vowelCount)
        {
            PrintFirstTwo(combined, vowels, false);
        }
        else
        {
            Console.WriteLine("Vowels and consonants are equal");
        }
    }

    private static void PrintFirstTwo(string word, HashSet<char> vowels, bool printVowels)
    {
        HashSet<char> printed = new HashSet<char>();
        int count = 0;

        foreach (char c in word)
        {
            bool isVowel = vowels.Contains(c);

            if (printVowels == isVowel && !printed.Contains(c))
            {
                Console.Write(c);
                printed.Add(c);
                count++;

                if (count == 2)
                    break;
            }
        }
        Console.WriteLine();
    }
}
