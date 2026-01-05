using System;

class Employee
{
    public string Name { get; set; }

    public Employee(string name)
    {
        Name = name;
    }
}

class Department
{
    public string DeptName { get; set; }
    public List<Employee> Employees { get; set; } = new List<Employee>();

    public Department(string name)
    {
        DeptName = name;
    }
}

class Company
{
    public string CompanyName { get; set; }
    public List<Department> Departments { get; set; } = new List<Department>();

    public Company(string name)
    {
        CompanyName = name;
    }
}

class Program
{
    static void Main()
    {
        Company comp = new Company("Tech Solutions");

        Department dev = new Department("Development");
        dev.Employees.Add(new Employee("Arvind"));
        dev.Employees.Add(new Employee("Bobby"));

        comp.Departments.Add(dev);

        Console.WriteLine("Company created with departments and employees");
    }
}
