using System;
class EmployeeUtilityImpl : IEmployee
{
    private Employee Employee;
    
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
}