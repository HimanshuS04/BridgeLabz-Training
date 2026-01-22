using System;
using System.IO;

class FileCopyUsingFileStream
{
    static void Main()
    {
        string source = "source.txt";
        string destination = "destination.txt";

        try
        {
            if (!File.Exists(source))
            {
                Console.WriteLine("Source file does not exist.");
                return;
            }

            using FileStream fsRead = new FileStream(source, FileMode.Open, FileAccess.Read);
            using FileStream fsWrite = new FileStream(destination, FileMode.Create, FileAccess.Write);

            int data;
            while ((data = fsRead.ReadByte()) != -1)
            {
                fsWrite.WriteByte((byte)data);
            }

            Console.WriteLine("File copied successfully.");
        }
        catch (IOException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
