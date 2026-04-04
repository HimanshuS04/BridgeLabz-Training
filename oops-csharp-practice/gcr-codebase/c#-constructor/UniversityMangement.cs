using System;

class UniversityManagement
{
    public int rollNumber;
    protected string name;
    private double CGPA;

    public void SetCGPA(double c)
    {
        CGPA = c;
    }

    public double GetCGPA()
    {
        return CGPA;
    }
}

class Postgraduate : UniversityManagement
{
    public void DisplayPG()
    {
        Console.WriteLine("Name: " + name); // protected access
    }

    static void Main()
    {
        Postgraduate pg = new Postgraduate();
        pg.rollNumber = 101;
        pg.name = "Amit";
        pg.SetCGPA(8.5);

        pg.DisplayPG();
        Console.WriteLine("CGPA: " + pg.GetCGPA());
    }
}
