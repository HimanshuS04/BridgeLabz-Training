using System;
class FrequentCharacters
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter a string: ");
        string str = Console.ReadLine();

        char frequentChar = FindFrequentCharacter(str);
        Console.WriteLine("Most frequent character: " + frequentChar);
    }

    public static char FindFrequentCharacter(string str)
    {
        int maxCount = 0;
        char frequentChar = ' ';
        for (int i = 0; i < str.Length; i++)
        {
            int count = 0;
            for (int j = 0; j < str.Length; j++)
            {
                if (str[i] == str[j])
                {
                    count++;
                }
            }
            if (count > maxCount)
            {
                maxCount = count;
                frequentChar = str[i];
            }
        }
        return frequentChar;
    }
}