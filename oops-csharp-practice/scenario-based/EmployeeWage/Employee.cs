using System;

public class Employee
{
    private int Id;
    private string Name;
    private bool IsPresent;
    private int WorkingHours;
    private int DailyWage;
    private int MonthlyWage;
    private string WorkType;

    public Employee(int Id, string Name)
    {
        this.Id = Id;
        this.Name = Name;
        this.WorkType = "Not Assigned";
    }
    public int GetId()
    {
        return Id;
    }
    public string GetName()
    {
        return Name;
    }
    public void SetAttendance(bool present)
    {
        IsPresent = present;
    }

    public bool GetAttendance()
    {
        return IsPresent;
    }
    public void SetWorkingHours(int hours)
    {
        WorkingHours = hours;
    }

    public int GetWorkingHours()
    {
        return WorkingHours;
    }
    public void SetDailyWage(int wage)
    {
        DailyWage = wage;
    }

    public int GetDailyWage()
    {
        return DailyWage;
    }
    public void SetMonthlyWage(int wage)
    {
        MonthlyWage = wage;
    }

    public int GetMonthlyWage()
    {
        return MonthlyWage;
    }
    public void SetWorkType(string type)
    {
        WorkType = type;
    }

    public string GetWorkType()
    {
        return WorkType;
    }
    
    public override string ToString()
    {
        return "ID: " + Id +
               "  Name: " + Name +
               "  Present: " + IsPresent +
               "  Hours: " + WorkingHours +
               "  Daily Wage: " + DailyWage +
               "  Monthly Wage: " + MonthlyWage +
               "  Work Type: " + WorkType;
    }
}
