class ExamCourse : CourseType
{
    public override void Evaluate()
    {
        Console.WriteLine($"{CourseName} - Exam Based");
    }
}
