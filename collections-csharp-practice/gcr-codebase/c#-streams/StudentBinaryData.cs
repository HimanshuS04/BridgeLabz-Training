using System;
using System.IO;

class StudentBinaryData
{
    static void Main()
    {
        using BinaryWriter bw = new BinaryWriter(File.Open("student.dat", FileMode.Create));
        bw.Write(101);
        bw.Write("Vansh");
        bw.Write(9.1);

        using BinaryReader br = new BinaryReader(File.Open("student.dat", FileMode.Open));
        Console.WriteLine(br.ReadInt32());
        Console.WriteLine(br.ReadString());
        Console.WriteLine(br.ReadDouble());
    }
}
