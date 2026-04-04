using System;

class OnlineCourseManagament
{
    // Instance variables
    public string courseName;
    public int duration;
    public double fee;

    // Class variable
    public static string instituteName = "ABC Institute";

    public OnlineCourseManagament(string name, int d, double f)
    {
        courseName = name;
        duration = d;
        fee = f;
    }

    // Instance method
    public void DisplayCourseDetails()
    {
        Console.WriteLine("OnlineCourseManagament Name   : " + courseName);
        Console.WriteLine("Duration      : " + duration + " months");
        Console.WriteLine("Fee           : " + fee);
        Console.WriteLine("Institute     : " + instituteName);
    }

    // Class method
    public static void UpdateInstituteName(string newName)
    {
        instituteName = newName;
    }

    static void Main()
    {
        OnlineCourseManagament c1 = new OnlineCourseManagament("C#", 3, 15000);
        c1.DisplayCourseDetails();

        OnlineCourseManagament.UpdateInstituteName("XYZ Technologies");

        OnlineCourseManagament c2 = new OnlineCourseManagament("Java", 4, 18000);
        c2.DisplayCourseDetails();
    }
}
