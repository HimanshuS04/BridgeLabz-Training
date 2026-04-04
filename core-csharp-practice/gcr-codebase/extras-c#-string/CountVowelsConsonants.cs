using System;
class CountVowelsConsonants
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter a string: ");
        string str = Console.ReadLine();

        int[] result = CountVowelsConsonant(str);
        int vowels = result[0];
        int consonants = result[1];
        Console.WriteLine($"Vowels: {vowels}, Consonants: {consonants}");
    }

    public static int[] CountVowelsConsonant(string str)
    {
        int vowels = 0;
        int consonants = 0;

        for(int i = 0; i < str.Length; i++)
        {
            if(isVowel(str[i]))
            {
                vowels++;
            }
            else if(char.IsLetter(str[i]))
            {
                consonants++;
            }
        }
        return new int[] { vowels, consonants };
    }

    public static bool isVowel(char c)
    {
        char lowerC = char.ToLower(c);
        return lowerC == 'a' || lowerC == 'e' || lowerC == 'i' || lowerC == 'o' || lowerC == 'u';
    }

}