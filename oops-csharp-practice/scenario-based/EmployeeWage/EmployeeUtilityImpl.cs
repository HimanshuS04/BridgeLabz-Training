using System;

public class EmployeeUtilityImpl : IEmployee
{
    private Employee Employee;
    private Random random = new Random();

    private const int WagePerHour = 20;
    private const int FullTimeHours = 8;
    private const int PartTimeHours = 8;

    public Employee[] CreateEmployees()
    {
        return new Employee[]
        {
            new Employee(101, "Rahul"),
            new Employee(102, "Aman"),
            new Employee(103, "Neha"),
            new Employee(104, "Priya"),
            new Employee(105, "Vikas"),
            new Employee(106, "Anjali"),
            new Employee(107, "Rohit"),
            new Employee(108, "Pooja"),
            new Employee(109, "Karan"),
            new Employee(110, "Sneha")
        };
    }

    public void SetEmployee(Employee Employee)
    {
        this.Employee = Employee;
    }

    public void CheckAttendance()
    {
        int attendance = random.Next(0, 2);
        Employee.SetAttendance(attendance == 1);
    }

    // UC2 + UC3 + UC4 
    public void CalculateDailyWage()
    {
        if (!Employee.GetAttendance())
        {
            Employee.SetWorkingHours(0);
            Employee.SetDailyWage(0);
            Employee.SetWorkType("Absent");
            return;
        }

        int workType = random.Next(1, 3); // 1 = Full Time, 2 = Part Time
        switch (workType)
        {
            case 1:
                Employee.SetWorkType("Full Time");
                Employee.SetWorkingHours(FullTimeHours);
                break;

            case 2:
                Employee.SetWorkType("Part Time");
                Employee.SetWorkingHours(PartTimeHours);
                break;

            default:
                Employee.SetWorkType("Absent");
                Employee.SetWorkingHours(0);
                break;
        }

        Employee.SetDailyWage(Employee.GetWorkingHours() * WagePerHour);
    }

    // UC5 + UC6
    public void CalculateMonthlyWage()
    {
        int totalHours = 0;
        int totalDays = 0;
        int totalWage = 0;

        while (totalHours < 100 && totalDays < 20)
        {
            CheckAttendance();

            if (!Employee.GetAttendance())
                continue;

            CalculateDailyWage();

            totalHours += Employee.GetWorkingHours();
            totalWage += Employee.GetDailyWage();
            totalDays++;
        }

        Employee.SetMonthlyWage(totalWage);
    }
}
