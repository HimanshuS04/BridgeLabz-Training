class CourseManager<T> where T : CourseType
{
    private List<T> courses = new List<T>();

    public void AddCourse(T course)
    {
        courses.Add(course);
    }

    public void EvaluateAll()
    {
        foreach (T c in courses)
            c.Evaluate();
    }
}
