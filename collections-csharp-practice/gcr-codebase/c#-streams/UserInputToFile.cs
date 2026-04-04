using System;
using System.IO;

class UserInputToFile
{
    static void Main()
    {
        try
        {
            using StreamReader reader = new StreamReader(Console.OpenStandardInput());
            using StreamWriter writer = new StreamWriter("userData.txt");

            Console.Write("Name: ");
            string name = reader.ReadLine();

            Console.Write("Age: ");
            string age = reader.ReadLine();

            Console.Write("Favorite Language: ");
            string lang = reader.ReadLine();

            writer.WriteLine($"Name: {name}");
            writer.WriteLine($"Age: {age}");
            writer.WriteLine($"Language: {lang}");

            Console.WriteLine("Data saved successfully.");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
