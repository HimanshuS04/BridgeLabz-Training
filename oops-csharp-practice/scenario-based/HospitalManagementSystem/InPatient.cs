using System;

public sealed class InPatient : Patient
{
    private int roomNumber;
    public int RoomNumber
    {
        get => roomNumber;
        set
        {
            if (value <= 0)
                throw new ArgumentException("Room number must be positive.");

            roomNumber = value;
        }
    }

    private DateTime admissionDate;
    public DateTime AdmissionDate
    {
        get => admissionDate;
        set
        {
            if (value > DateTime.Now)
                throw new ArgumentException("Admission date cannot be in the future.");

            admissionDate = value;
        }
    }

    public InPatient(int id, string name, int age, int roomNumber, DateTime admissionDate, Doctor assignedDoctor)
        : base(id, name, age, assignedDoctor)
    {
        RoomNumber = roomNumber;
        AdmissionDate = admissionDate;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Room Number: {roomNumber}, Admission Date: {admissionDate.ToShortDateString()}");
    }
}
