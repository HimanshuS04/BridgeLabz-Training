using System;
public class Student
{
    private int RollNum;
    private string Name;
    private int Marks;
    private string District;
    public Student(int rollNum, string name, int marks, string district)
    {
        RollNum = rollNum;
        Name = name;
        Marks = marks;
        District = district;
    }
    public int GetRollNum()
    {
        return RollNum;
    }
    public void SetRollNum(int rollNum)
    {
        RollNum = rollNum;
    }
    public string GetName()
    {
        return Name;
    }
    public void SetName(string name)
    {
        Name = name;
    }
    public int GetMarks()
    {
        return Marks;
    }
    public void SetMarks(int marks)
    {
        Marks = marks;
    }
    public string GetDistrict()
    {
        return District;
    }
    public void SetDistrict(string district)
    {
        District = district;
    }
    public override string ToString()
    {
        return RollNum + " | " + Name + " | " + Marks + " | " + District;
    }
}