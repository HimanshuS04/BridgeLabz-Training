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
            Random random = new Random();
            int empType = random.Next(0, 3); 

            int workingHours = 0;

            if (empType == 1)
            {
                workingHours = FullTime;
            }
            else if (empType == 2)
            {
                workingHours = random.Next(1, FullTime);
            }

            Employee.SetWorkingHours(workingHours);
            Employee.SetDailyWage(workingHours * WageHour);
        }
}