using System;

public class Patient
{
    private readonly Doctor assignedDoctor;
    private int id;
    private string name;
    private int age;

    public Doctor AssignedDoctor => assignedDoctor;

    public int Id
    {
        get => id;
        set
        {
            if (value <= 0)
                throw new ArgumentException("ID must be positive.");
            id = value;
        }
    }

    public string Name
    {
        get => name;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Name cannot be empty.");
            name = value;
        }
    }

    public int Age
    {
        get => age;
        set
        {
            if (value < 0)
                throw new ArgumentException("Age cannot be negative.");
            age = value;
        }
    }

    public Patient(int id, string name, int age, Doctor assignedDoctor)
    {
        Id = id;
        Name = name;
        Age = age;
        this.assignedDoctor = assignedDoctor
            ?? throw new ArgumentNullException(nameof(assignedDoctor));
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Id: {id}, Name: {name}, Age: {age}");
        Console.WriteLine($"Assigned Doctor: {assignedDoctor.Name}");
    }
}
