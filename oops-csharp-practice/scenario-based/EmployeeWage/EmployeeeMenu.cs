using System;

public class EmployeeMenu
{
    EmployeeUtilityImpl Service = new EmployeeUtilityImpl();
    Employee[] Employees;

    public void MainMenu()
    {
        Employees = Service.CreateEmployees();

        int choice;
        do
        {
            Console.WriteLine("     Employee Wage System ");
            Console.WriteLine("1. Check Attendance");
            Console.WriteLine("2. Calculate Daily Wage");
            Console.WriteLine("3. Calculate Monthly Wage");
            Console.WriteLine("4. Exit");
            Console.Write("Enter choice: ");

            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    CheckAttendance();
                    break;

                case 2:
                    CalculateDailyWage();
                    break;

                case 3:
                    CalculateMonthlyWage();
                    break;
            }
        }
        while (choice != 4);
    }

    void CheckAttendance()
    {
        foreach (Employee emp in Employees)
        {
            Service.SetEmployee(emp);
            Service.CheckAttendance();
        }
        Display();
    }

    void CalculateDailyWage()
    {
        foreach (Employee emp in Employees)
        {
            Service.SetEmployee(emp);
            Service.CheckAttendance();
            Service.CalculateDailyWage();
        }
        Display();
    }

    void CalculateMonthlyWage()
    {
        foreach (Employee emp in Employees)
        {
            Service.SetEmployee(emp);
            Service.CalculateMonthlyWage();
        }
        Display();
    }

    void Display()
    {
        Console.WriteLine("\n---- Employee Details ----");
        foreach (Employee emp in Employees)
            Console.WriteLine(emp);
    }
}
