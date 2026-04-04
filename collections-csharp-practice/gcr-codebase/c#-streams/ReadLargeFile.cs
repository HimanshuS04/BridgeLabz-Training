using System;
using System.IO;

class ReadLargeFile
{
    static void Main()
    {
        using StreamReader sr = new StreamReader("largeLog.txt");

        string line;
        while ((line = sr.ReadLine()) != null)
        {
            if (line.ToLower().Contains("error"))
                Console.WriteLine(line);
        }
    }
}
