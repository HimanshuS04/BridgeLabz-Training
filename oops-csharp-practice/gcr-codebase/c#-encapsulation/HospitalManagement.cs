using System;

interface IMedicalRecord
{
    void AddRecord(string record);
    void ViewRecords();
}

abstract class Patient
{
    protected int patientId;
    protected string name;

    public Patient(int id, string name)
    {
        patientId = id;
        this.name = name;
    }

    public abstract double CalculateBill();

    public void GetPatientDetails()
    {
        Console.WriteLine("Patient: " + name);
    }
}

class InPatient : Patient
{
    public InPatient(int id, string name) : base(id, name) { }

    public override double CalculateBill()
    {
        return 5000;
    }
}
