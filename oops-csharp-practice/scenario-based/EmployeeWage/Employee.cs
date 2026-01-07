using System;
public class Employee
{

    private int EmployeeId{get; set;}
    private string EmployeeName{get; set;}

    private bool IsPresent{get; set;}

    private double DailyWage{get; set;}

    public void SetEmployeeID(int id)
    {
        EmployeeId = id;
    }


    public void SetEmployeeName(string name)
    {
        EmployeeName = name;
    }

    public void SetAttendance(bool present)
    {
        IsPresent = present;
    }

    public bool GetAttendance()
        {
            return IsPresent;
        }
    public override string ToString()
    {
       string status = IsPresent ? "Present" : "Absent";
       return $"ID: {EmployeeId}, Name: {EmployeeName}, Status: {status}";
    }
}