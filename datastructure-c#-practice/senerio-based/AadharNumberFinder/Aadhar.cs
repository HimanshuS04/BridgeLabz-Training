using System;
public class Aadhar
{
    private long AadharNumber;
    private string Name;
    private int Age;
    private string DOB;

    public Aadhar(long aadharnum, string name, int age, string dob)
    {
        AadharNumber = aadharnum;
        Name = name;
        Age = age;
        DOB = dob;
    }
    public long GetAadharNumber()
    {
        return AadharNumber;
    }
    public void SetAadharNumber(long aadharnum)
    {
        AadharNumber = aadharnum;
    }
    public string GetName()
    {
        return Name;
    }
    public void SetName(string name)
    {
        Name = name;
    }
    public int GetAge()
    {
        return Age;
    }
    public void SetAge(int age)
    {
        Age = age;
    }
    public string GetDOB()
    {
        return DOB;
    }
    public void SetDOB(string dob)
    {
        DOB = dob;
    }
    public override string ToString()
    {
        return "Aadhar: " + AadharNumber +
               ", Name: " + Name +
               ", Age: " + Age +
               ", DOB: " + DOB;
    }
}