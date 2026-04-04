
using System;
class Person
{
    public string Name;
    public int Age;
}
class Teacher : Person
{
    public string Subject;
    public void DisplayRole(){ Console.WriteLine("Teacher"); }
}
class Student : Person
{
    public string Grade;
    public void DisplayRole(){ Console.WriteLine("Student"); }
}
class Staff : Person
{
    public string Department;
    public void DisplayRole(){ Console.WriteLine("Staff"); }
}
class Program
{
    static void Main()
    {
        Student s = new Student();
        s.DisplayRole();
    }
}
