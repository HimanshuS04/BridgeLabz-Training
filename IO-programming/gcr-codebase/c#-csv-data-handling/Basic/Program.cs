using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        string[] lines = File.ReadAllLines("students.csv");

        Console.WriteLine("Student Records:");
        foreach (string line in lines.Skip(1))
        {
            string[] data = line.Split(',');
            Console.WriteLine($"ID: {data[0]}, Name: {data[1]}, Age: {data[2]}, Marks: {data[3]}");
        }

        Console.WriteLine("\nTotal Records: " + (lines.Length - 1));
    }
}
