using System;

class EmployeeMangement
{
    public static string CompanyName = "Tech Corp";
    private static int totalEmployeeMangements = 0;

    public string Name;
    public readonly int Id;
    public string Designation;

    public EmployeeMangement(string Name, int Id, string Designation)
    {
        this.Name = Name;
        this.Id = Id;
        this.Designation = Designation;
        totalEmployeeMangements++;
    }

    public static void DisplayEmployeeMangements()
    {
        Console.WriteLine("Total EmployeeMangements: " + totalEmployeeMangements);
    }

    public void Display(object obj)
    {
        if (obj is EmployeeMangement)
        {
            Console.WriteLine(Name + " - " + Designation);
        }
    }
}

class Program
{
    static void Main()
    {
        EmployeeMangement e1 = new EmployeeMangement("Ravi", 1, "Developer");
        e1.Display(e1);
        EmployeeMangement.DisplayEmployeeMangements();
    }
}
