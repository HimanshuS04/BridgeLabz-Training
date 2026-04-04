using System;

class Course
{
    public string CourseName;
}

class Professor
{
    public string Name;

    public void AssignProfessor(Course course)
    {
        Console.WriteLine($"Professor {Name} assigned to {course.CourseName}");
    }
}

class Student
{
    public string Name;

    public void EnrollCourse(Course course)
    {
        Console.WriteLine($"Student {Name} enrolled in {course.CourseName}");
    }
}

class Program
{
    static void Main()
    {
        Course c = new Course { CourseName = "Artificial Intelligence and Machine Learning  " };

        Student s = new Student { Name = "Himanshu" };
        Professor p = new Professor { Name = "Dr. Singh" };

        s.EnrollCourse(c);
        p.AssignProfessor(c);
    }
}
