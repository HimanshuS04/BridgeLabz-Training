class ResumeMain
{
    static void Main()
    {
        ResumeProcessor<SoftwareEngineer> processor =
            new ResumeProcessor<SoftwareEngineer>();

        processor.Add(new SoftwareEngineer());
        processor.Process();
    }
}
