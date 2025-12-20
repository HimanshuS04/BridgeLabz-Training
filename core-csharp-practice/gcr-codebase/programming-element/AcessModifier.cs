using System;

// Base class
public class Person
{
    public string fullName = "Amit Sharma";        // public
    private int age = 28;                          // private
    protected string gender = "Male";              // protected
    internal string city = "Bengaluru";             // internal
    protected internal string country = "India";   // protected internal
    private protected double monthlySalary = 55000;// private protected

    public void ShowAge()
    {
        Console.WriteLine("Age: " + age);
    }
}

// Derived class

public class Student : Person
{
    public void DisplayDetails()
    {
        Console.WriteLine("Name: " + fullName);        // public
        Console.WriteLine("Gender: " + gender);        // protected
        Console.WriteLine("City: " + city);            // internal
        Console.WriteLine("Country: " + country);      // protected internal
        Console.WriteLine("Salary: " + monthlySalary); // private protected

        //Not accessible
        // Console.WriteLine(age);
    }
}


// Non-derived class

class Teacher
{
    void TestAccess()
    {
        Person prsn = new Person();

        Console.WriteLine(prsn.fullName);  // public
        Console.WriteLine(prsn.city);      //  internal
        Console.WriteLine(prsn.country);   //  protected internal

        /*  Not accessible
         prsn.gender;
         prsn.monthlySalary;
         prsn.age;*/
    }
}

// Main class

class AcessModifier
{
    static void Main(string[] args)
    {
        Person prsn = new Person();
        Console.WriteLine("Person Name: " + prsn.fullName);
        prsn.ShowAge();

        Student student = new Student();
        student.DisplayDetails();

        Console.WriteLine("Program finished successfully.");
    }
}
