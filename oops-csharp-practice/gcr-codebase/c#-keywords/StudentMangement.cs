using System;

class StudentMangement
{
    public static string UniversityName = "GLA University";
    private static int totalStudents = 0;

    public string Name;
    public readonly int RollNumber;
    public string Grade;

    public StudentMangement(string Name, int RollNumber, string Grade)
    {
        this.Name = Name;
        this.RollNumber = RollNumber;
        this.Grade = Grade;
        totalStudents++;
    }

    public static void DisplayStudents()
    {
        Console.WriteLine("Total Students: " + totalStudents);
    }

    public void Display(object obj)
    {
        if (obj is StudentMangement)
        {
            Console.WriteLine(Name + " - Grade: " + Grade);
        }
    }
}

class Program
{
    static void Main()
    {
        StudentMangement s1 = new StudentMangement("Neha", 12, "A");
        s1.Display(s1);
        StudentMangement.DisplayStudents();
    }
}
