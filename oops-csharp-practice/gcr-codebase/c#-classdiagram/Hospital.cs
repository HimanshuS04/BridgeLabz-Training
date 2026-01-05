using System;

class Patient
{
    public string Name;
}

class Doctor
{
    public string Name;

    public void Consult(Patient patient)
    {
        Console.WriteLine($"Dr. {Name} is consulting {patient.Name}");
    }
}

class Program
{
    static void Main()
    {
        Doctor d1 = new Doctor { Name = " Raja Sharma" };
        Doctor d2 = new Doctor { Name = "Mohit" };

        Patient p1 = new Patient { Name = "Rohit Rana" };
        Patient p2 = new Patient { Name = "Anee" };

        d1.Consult(p1);
        d1.Consult(p2);
        d2.Consult(p1);
    }
}
