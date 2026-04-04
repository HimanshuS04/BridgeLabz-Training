using System;

class HospitalMangement
{
    public static string HospitalName = "City Hospital";
    private static int totalPatients = 0;

    public string Name;
    public int Age;
    public string Ailment;
    public readonly int PatientID;

    public HospitalMangement(string Name, int Age, string Ailment, int PatientID)
    {
        this.Name = Name;
        this.Age = Age;
        this.Ailment = Ailment;
        this.PatientID = PatientID;
        totalPatients++;
    }

    public static void GetTotalPatients()
    {
        Console.WriteLine("Total Patients: " + totalPatients);
    }

    public void Display(object obj)
    {
        if (obj is HospitalMangement)
        {
            Console.WriteLine(Name + " - " + Ailment);
        }
    }
}

class Program
{
    static void Main()
    {
        HospitalMangement p1 = new HospitalMangement("Sita", 30, "Fever", 1001);
        HospitalMangement p2 = new HospitalMangement("Ravi", 25, "Headache", 1002);
        HospitalMangement p3 = new HospitalMangement("Priya", 35, "Cough", 1003);

        p1.Display(p1);
        p2.Display(p2);
        p3.Display(p3);
        HospitalMangement.GetTotalPatients();
    }
}
