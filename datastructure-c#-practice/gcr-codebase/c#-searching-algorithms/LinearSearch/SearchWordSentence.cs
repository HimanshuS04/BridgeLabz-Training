using System;

class SearchWordInSentence
{
    static void Main()
    {
        string[] sentences =
        {
            "C sharp is powerful",
            "Java is object oriented",
            "Python is easy",
            "I love programming"
        };

        string word = "Python";
        int index = -1;

        for (int i = 0; i < sentences.Length; i++)
        {
            if (sentences[i].Contains(word))
            {
                index = i;
                break;
            }
        }

        Console.WriteLine("Sentence Index: " + index);
    }
}
