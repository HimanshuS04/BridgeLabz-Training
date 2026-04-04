using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class WordFrequency
{
    static void Main()
    {
        Dictionary<string, int> words = new();

        using StreamReader sr = new StreamReader("text.txt");
        string line;

        while ((line = sr.ReadLine()) != null)
        {
            foreach (string word in line.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            {
                string w = word.ToLower();
                words[w] = words.ContainsKey(w) ? words[w] + 1 : 1;
            }
        }

        foreach (var item in words.OrderByDescending(x => x.Value).Take(5))
            Console.WriteLine($"{item.Key} : {item.Value}");
    }
}
