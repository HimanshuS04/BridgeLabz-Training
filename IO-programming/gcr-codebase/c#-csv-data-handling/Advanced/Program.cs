using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        ValidateCSV();
        MergeCSV();
        ReadLargeCSV();
        JsonToCsv();
    }

    static void ValidateCSV()
    {
        Console.WriteLine("\nInvalid Records:");
        Regex email = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        Regex phone = new Regex(@"^\d{10}$");

        foreach (var line in File.ReadAllLines("users.csv").Skip(1))
        {
            var d = line.Split(',');
            if (!email.IsMatch(d[1]) || !phone.IsMatch(d[2]))
                Console.WriteLine(line + " ❌ Invalid");
        }
    }

    static void MergeCSV()
    {
        var file1 = File.ReadAllLines("students1.csv").Skip(1)
            .Select(l => l.Split(',')).ToDictionary(d => d[0]);

        var file2 = File.ReadAllLines("students2.csv").Skip(1)
            .Select(l => l.Split(','));

        List<string> merged = new List<string> { "ID,Name,Age,Marks,Grade" };

        foreach (var d in file2)
        {
            var s = file1[d[0]];
            merged.Add($"{d[0]},{s[1]},{s[2]},{d[1]},{d[2]}");
        }

        File.WriteAllLines("merged_students.csv", merged);
    }

    static void ReadLargeCSV()
    {
        int count = 0;
        using StreamReader sr = new StreamReader("bigdata.csv");
        sr.ReadLine();

        while (!sr.EndOfStream)
        {
            sr.ReadLine();
            count++;
            if (count % 100 == 0)
                Console.WriteLine($"Processed {count} records");
        }
    }

    static void JsonToCsv()
    {
        var students = JsonSerializer.Deserialize<List<Student>>(
            File.ReadAllText("students.json"));

        List<string> csv = new List<string> { "Id,Name,Age,Marks" };
        foreach (var s in students)
            csv.Add($"{s.Id},{s.Name},{s.Age},{s.Marks}");

        File.WriteAllLines("students_from_json.csv", csv);
    }
}
