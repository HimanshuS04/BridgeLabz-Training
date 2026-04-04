using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public double Salary { get; set; }
}

class EmployeeSerialization
{
    static void Main()
    {
        List<Employee> employees = new()
        {
            new Employee{ Id=1, Name="Amit", Department="IT", Salary=50000 },
            new Employee{ Id=2, Name="Riya", Department="HR", Salary=45000 }
        };

        try
        {
            string file = "employees.json";

            File.WriteAllText(file, JsonSerializer.Serialize(employees));

            var data = JsonSerializer.Deserialize<List<Employee>>(File.ReadAllText(file));

            foreach (var e in data)
                Console.WriteLine($"{e.Id} {e.Name} {e.Department} {e.Salary}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
