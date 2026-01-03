using System;

class EmployeeRecord
{
    public int employeeID;
    protected string department;
    private double salary;

    public void SetSalary(double s)
    {
        salary = s;
    }

    public double GetSalary()
    {
        return salary;
    }
}

class Manager : EmployeeRecord
{
    public void DisplayManager()
    {
        Console.WriteLine("EmployeeRecord ID: " + employeeID);
        Console.WriteLine("Department : " + department);
    }

    static void Main()
    {
        Manager m = new Manager();
        m.employeeID = 501;
        m.department = "IT";
        m.SetSalary(75000);

        m.DisplayManager();
        Console.WriteLine("Salary: " + m.GetSalary());
    }
}
