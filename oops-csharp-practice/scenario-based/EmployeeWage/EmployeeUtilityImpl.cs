using System;
class EmployeeUtilityImpl : IEmployee
{
    private Employee Employee;

    private const int WageHour = 20;
    private const int FullTime = 8;
    
    public void SetEmployee(Employee employee)
    {
        Employee = employee;
    }
    public void CheckAttendance()
    {
        Random random = new Random();
        int attendance = random.Next(0, 2); // 0 or 1

        if (attendance == 1)
            Employee.SetAttendance(true);
        else
            Employee.SetAttendance(false);
    }

   public void CalculateDailyWage()
    {
        const int FullTime = 8;
        const int WageHour = 20;
        if (!Employee.GetAttendance())
        {
            Employee.SetWorkingHours(0);
            Employee.SetDailyWage(0);
            Employee.SetWorkType("Absent");
            return;
        }

        Random random = new Random();
        int workType = random.Next(0, 2);

        if (workType == 0)
        {

            Employee.SetWorkType("Full Time");
            Employee.SetWorkingHours(FullTime);
            Employee.SetDailyWage(FullTime * WageHour);
        }
        else
        {

            int partTimeHours = random.Next(1, 8); 

            Employee.SetWorkType("Part Time");
            Employee.SetWorkingHours(partTimeHours);
            Employee.SetDailyWage(partTimeHours * WageHour + FullTime * WageHour);
        }
    }
}