using System;

class Employee
{
    public string name;
    public int id;
    public double salary;

    public void DisplayDetails()
    {
        Console.WriteLine("Employee Name  : " + name);
        Console.WriteLine("Employee ID    : " + id);
        Console.WriteLine("Employee Salary: " + salary);
    }

    static void Main(string[] args)
    {
        Employee emp = new Employee();

        emp.name = "Rahul";
        emp.id = 101;
        emp.salary = 25000;

        emp.DisplayDetails();
    }
}
