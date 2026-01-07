using System;

interface IDepartment
{
    void AssignDepartment(string dept);
    string GetDepartmentDetails();
}

abstract class Employee
{
    private int employeeId;
    private string name;
    protected double baseSalary;
    protected string department;

    public int EmployeeId
    {
        get { return employeeId; }
        set { employeeId = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public Employee(int id, string name, double salary)
    {
        employeeId = id;
        this.name = name;
        baseSalary = salary;
    }

    public abstract double CalculateSalary();

    public void DisplayDetails()
    {
        Console.WriteLine("ID: " + employeeId +
                          ", Name: " + name +
                          ", Salary: " + CalculateSalary() +
                          ", Dept: " + department);
    }
}

class FullTimeEmployee : Employee, IDepartment
{
    public FullTimeEmployee(int id, string name, double salary)
        : base(id, name, salary) { }

    public override double CalculateSalary()
    {
        return baseSalary;
    }

    public void AssignDepartment(string dept)
    {
        department = dept;
    }

    public string GetDepartmentDetails()
    {
        return department;
    }
}

class PartTimeEmployee : Employee, IDepartment
{
    private int hoursWorked;

    public PartTimeEmployee(int id, string name, double rate, int hours)
        : base(id, name, rate)
    {
        hoursWorked = hours;
    }

    public override double CalculateSalary()
    {
        return baseSalary * hoursWorked;
    }

    public void AssignDepartment(string dept)
    {
        department = dept;
    }

    public string GetDepartmentDetails()
    {
        return department;
    }
}

class Program
{
    static void Main()
    {
        Employee[] employees = new Employee[2];
        employees[0] = new FullTimeEmployee(1, "Amit", 50000);
        employees[1] = new PartTimeEmployee(2, "Ravi", 500, 80);

        for (int i = 0; i < employees.Length; i++)
            employees[i].DisplayDetails();
    }
}
