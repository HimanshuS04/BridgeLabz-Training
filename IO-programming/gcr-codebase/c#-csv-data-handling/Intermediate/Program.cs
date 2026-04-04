using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        FilterStudents();
        SearchEmployee("Amit");
        UpdateSalary();
        SortEmployees();
    }

    static void FilterStudents()
    {
        Console.WriteLine("\nStudents with Marks > 80:");
        foreach (var line in File.ReadAllLines("students.csv").Skip(1))
        {
            var d = line.Split(',');
            if (int.Parse(d[3]) > 80)
                Console.WriteLine($"{d[1]} - {d[3]}");
        }
    }

    static void SearchEmployee(string name)
    {
        Console.WriteLine("\nEmployee Search:");
        foreach (var line in File.ReadAllLines("employees.csv").Skip(1))
        {
            var d = line.Split(',');
            if (d[1].Equals(name, StringComparison.OrdinalIgnoreCase))
                Console.WriteLine($"Dept: {d[2]}, Salary: {d[3]}");
        }
    }

    static void UpdateSalary()
    {
        List<string> updated = new List<string> { "ID,Name,Department,Salary" };

        foreach (var line in File.ReadAllLines("employees.csv").Skip(1))
        {
            var d = line.Split(',');
            double salary = double.Parse(d[3]);

            if (d[2] == "IT")
                salary *= 1.10;

            updated.Add($"{d[0]},{d[1]},{d[2]},{salary}");
        }

        File.WriteAllLines("updated_employees.csv", updated);
    }

    static void SortEmployees()
    {
        Console.WriteLine("\nTop 5 Highest Paid Employees:");
        var employees = File.ReadAllLines("employees.csv")
            .Skip(1)
            .Select(l =>
            {
                var d = l.Split(',');
                return new Employee
                {
                    Id = int.Parse(d[0]),
                    Name = d[1],
                    Department = d[2],
                    Salary = double.Parse(d[3])
                };
            })
            .OrderByDescending(e => e.Salary)
            .Take(5);

        foreach (var e in employees)
            Console.WriteLine($"{e.Name} - {e.Salary}");
    }
}
