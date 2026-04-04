
using System;
class Course
{
    public string CourseName;
    public int Duration;
}
class OnlineCourse : Course
{
    public string Platform;
    public bool IsRecorded;
}
class PaidOnlineCourse : OnlineCourse
{
    public double Fee;
    public double Discount;
}
class Program
{
    static void Main()
    {
        PaidOnlineCourse p = new PaidOnlineCourse();
        p.CourseName = "AI";
        p.Fee = 5000;
        Console.WriteLine(p.CourseName + " " + p.Fee);
    }
}
