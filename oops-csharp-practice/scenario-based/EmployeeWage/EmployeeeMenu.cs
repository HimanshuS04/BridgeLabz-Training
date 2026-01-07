using System;

public sealed class EmployeeMenu
{
    private IEmployee employeeService = new EmployeeUtilityImpl();
    private Employee[] employees;

    public EmployeeMenu()
    {
        employees = new Employee[10];

        employees[0] = CreateEmployee(101, "Rahul");
        employees[1] = CreateEmployee(102, "Aman");
        employees[2] = CreateEmployee(103, "Neha");
        employees[3] = CreateEmployee(104, "Priya");
        employees[4] = CreateEmployee(105, "Vikas");
        employees[5] = CreateEmployee(106, "Anjali");
        employees[6] = CreateEmployee(107, "Rohit");
        employees[7] = CreateEmployee(108, "Pooja");
        employees[8] = CreateEmployee(109, "Karan");
        employees[9] = CreateEmployee(110, "Sneha");
    }

    public void MainMenu()
    {
        int choice;

        do
        {
            Console.WriteLine("\n===== Employee Wage System =====");
            Console.WriteLine("1. Check Attendance");
            Console.WriteLine("2. Calculate Daily Wage");
            Console.WriteLine("3. Display Employees");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");

            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    CheckAttendance();
                    break;

                case 2:
                    CalculateDailyWage();
                    break;

                case 3:
                    DisplayEmployees();
                    break;

                case 4:
                    Console.WriteLine("Exiting Application...");
                    break;

                default:
                    Console.WriteLine("Invalid Choice! Try again.");
                    break;
            }

        } while (choice != 4);
    }

    private void CheckAttendance()
    {
        foreach (Employee emp in employees)
        {
            employeeService.SetEmployee(emp);
            employeeService.CheckAttendance();
        }
        Console.WriteLine("Attendance Checked Successfully.");
    }

    private void CalculateDailyWage()
    {
        foreach (Employee emp in employees)
        {
            employeeService.SetEmployee(emp);
            employeeService.CalculateDailyWage();
        }
        Console.WriteLine("Daily Wage Calculated Successfully.");
    }

    private void DisplayEmployees()
    {
        Console.WriteLine("\n---- Employee Details ----");
        foreach (Employee emp in employees)
        {
            Console.WriteLine(emp);
        }
    }

    private Employee CreateEmployee(int id, string name)
    {
        Employee emp = new Employee();
        emp.SetEmployeeID(id);
        emp.SetEmployeeName(name);
        return emp;
    }
}
