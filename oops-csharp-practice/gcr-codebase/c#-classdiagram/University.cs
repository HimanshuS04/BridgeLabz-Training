using System;

class Faculty
{
    public string Name;
}

class Department
{
    public string DeptName;
}

class University
{
    public List<Department> Departments = new List<Department>();
    public List<Faculty> Faculties = new List<Faculty>();

    public void DeleteUniversity()
    {
        Departments.Clear();
        Console.WriteLine("\nUniversity deleted");
        Console.WriteLine("All departments removed");
    }
}

class Program
{
    static void Main()
    {
        University uni = new University();

        uni.Departments.Add(new Department { DeptName = "CSE" });
        uni.Departments.Add(new Department { DeptName = "AI & ML" });

        Faculty f1 = new Faculty { Name = "Dr. Sharma" };
        uni.Faculties.Add(f1);

        Console.WriteLine("University created");
        Console.WriteLine("Departments added");
        Console.WriteLine("Faculty added");

        uni.DeleteUniversity();

        Console.WriteLine($"Faculty still exists: {f1.Name}");
    }
}
