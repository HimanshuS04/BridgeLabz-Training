using System;

class Course
{
    public string CourseName;
    public List<StudentMangement> Students = new List<StudentMangement>();
}

class StudentMangement
{
    public string Name;
    public List<Course> Courses = new List<Course>();

    public void Enroll(Course course)
    {
        Courses.Add(course);
        course.Students.Add(this);
        Console.WriteLine($"{Name} enrolled in {course.CourseName}");
    }

    public void ShowCourses()
    {
        Console.WriteLine($"\nCourses of {Name}:");
        foreach (var c in Courses)
            Console.WriteLine(c.CourseName);
    }
}

class School
{
    public List<StudentMangement> Students = new List<StudentMangement>();
}

class Program
{
    static void Main()
    {
        School school = new School();

        StudentMangement s1 = new StudentMangement { Name = "Raghav" };
        StudentMangement s2 = new StudentMangement { Name = "Aarav" };

        Course c1 = new Course { CourseName = "Artificial Intelligence" };
        Course c2 = new Course { CourseName = "Machine Learning" };

        school.Students.Add(s1);
        school.Students.Add(s2);

        s1.Enroll(c1);
        s1.Enroll(c2);
        s2.Enroll(c1);

        s1.ShowCourses();
        s2.ShowCourses();

        Console.WriteLine("\nStudents enrolled in AI:");
        foreach (var s in c1.Students)
            Console.WriteLine(s.Name);
    }
}
