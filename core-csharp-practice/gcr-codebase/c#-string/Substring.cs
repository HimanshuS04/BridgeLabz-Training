using System;
class Substring
{
    static void Main(string[] args)
    {   Console.WriteLine("Enter the string:");
        string str=Console.ReadLine();
        int sIndex=int.Parse(Console.ReadLine());
        int lIndex=int.Parse(Console.ReadLine());
        string result=CreateSubstring(str,sIndex,lIndex);
        string result1=str.Substring(sIndex,lIndex-sIndex+1);
        Console.WriteLine(result);
        Console.WriteLine(result1);

    }
    static string CreateSubstring(string str,int sIndex,int lIndex)
    {
        string result="";
        for(int i = sIndex; i <= lIndex; i++)
        {
            result+=str[i];
        }
        return result;
    }
}