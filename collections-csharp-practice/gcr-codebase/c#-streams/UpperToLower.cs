using System;
using System.IO;

class UpperToLower
{
    static void Main()
    {
        try
        {
            using StreamReader sr = new StreamReader("input.txt");
            using StreamWriter sw = new StreamWriter("output.txt");

            string line;
            while ((line = sr.ReadLine()) != null)
                sw.WriteLine(line.ToLower());
        }
        catch (IOException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
