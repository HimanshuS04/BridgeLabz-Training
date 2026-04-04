class ResumeProcessor<T> where T : JobRole
{
    private List<T> resumes = new List<T>();

    public void Add(T role)
    {
        resumes.Add(role);
    }

    public void Process()
    {
        foreach (T r in resumes)
            r.Evaluate();
    }
}
