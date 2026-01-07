using System;

class EmployeeUtilityImpl : IEmployee
{
    private Employee employee;

    private const int WagePerHour = 20;
    private const int FullTimeHours = 8;

    private Random random = new Random();

    public void SetEmployee(Employee employee)
    {
        this.employee = employee;
    }

    public void CheckAttendance()
    {
        int attendance = random.Next(0, 2); // 0 = Absent, 1 = Present

        if (attendance == 1)
            employee.SetAttendance(true);
        else
            employee.SetAttendance(false);
    }

    public void CalculateDailyWage()
    {
        if (!employee.GetAttendance())
        {
            employee.SetWorkingHours(0);
            employee.SetDailyWage(0);
            employee.SetWorkType("Absent");
            return;
        }

        int workType = random.Next(0, 2); // 0 = Full Time, 1 = Part Time

        if (workType == 0)
        {
            employee.SetWorkType("Full Time");
            employee.SetWorkingHours(FullTimeHours);
            employee.SetDailyWage(FullTimeHours * WagePerHour);
        }
        else
        {
            int partTimeHours = random.Next(1, FullTimeHours);

            employee.SetWorkType("Part Time");
            employee.SetWorkingHours(partTimeHours);
            employee.SetDailyWage(partTimeHours * WagePerHour);
        }
    }
}
