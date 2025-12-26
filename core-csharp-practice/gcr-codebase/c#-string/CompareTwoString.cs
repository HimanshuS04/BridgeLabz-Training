using System;
class CompareTwoString
{
    static void Main(string[] args)
    {
        string str1=Console.ReadLine();
        string str2=Console.ReadLine();
        bool result=CompareString(str1,str2);
        bool result1=string.Equals(str1,str2);
        Console.WriteLine(result);
        Console.WriteLine(result1);
    }
    static bool CompareString(string str1,string str2)
    {

        if (str1.Length != str2.Length)
        {
            return false;
        }
        for(int i = 0; i < str1.Length; i++)
        {
            if (str1[i] != str2[i])
            {
                return false;
            }
        }
        return true;
    }
}