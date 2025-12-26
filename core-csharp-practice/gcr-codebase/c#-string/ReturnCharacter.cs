using System;
class ReturnCharacter
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the string:");
        string str=Console.ReadLine();
        char[] result=GetCharacter(str);
        foreach(char c in result)
        {
            Console.Write(c+" ");
        }
        Console.WriteLine();
        char[] result1=str.ToCharArray();
        foreach(char c in result1)
        {
            Console.Write(c+" ");
        }
    }
    static char[] GetCharacter(string str)
    {
        char[] charArray= new char[str.Length];
        for(int i = 0; i < str.Length; i++)
        {
            charArray[i]=str[i];
        }
        return charArray;

     }
}