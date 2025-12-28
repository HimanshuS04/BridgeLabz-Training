using System;
using System.Reflection.PortableExecutable;
class ToggleCase
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter a string: ");
        string str = Console.ReadLine();

        string toggled = ToggleCaseString(str);
        Console.WriteLine("Toggled case string: " + toggled);
    }

    public static string ToggleCaseString(string str)
    {
        char[] characters = str.ToCharArray();
        for(int i = 0; i < str.Length; i++)
        {
            if(char.IsUpper(characters[i]))
            {
                characters[i] = char.ToLower(characters[i]);
            }
            else if(char.IsLower(characters[i]))
            {
                characters[i] = char.ToUpper(characters[i]);
            }
        }
        return new string(characters);
    }
}