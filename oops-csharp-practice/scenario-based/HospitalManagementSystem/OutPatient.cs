using System;

public class OutPatient : Patient
{
    private DateTime visitDate;

    public DateTime VisitDate
    {
        get => visitDate;
        set
        {
            if (value > DateTime.Now)
                throw new ArgumentException("Visit date cannot be in the future.");

            visitDate = value;
        }
    }

    public OutPatient(int id, string name, int age, DateTime visitDate, Doctor assignedDoctor)
        : base(id, name, age, assignedDoctor)
    {
        VisitDate = visitDate;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Visit Date: {visitDate:yyyy-MM-dd}");
    }
}
