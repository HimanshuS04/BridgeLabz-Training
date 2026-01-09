using System;

class ClassNode
{
    public int roll;
    public string name;
    public int age;
    public char grade;
    public ClassNode next;
}

class StudentList
{
    ClassNode head;

    public void AddAtEnd(int r, string n, int a, char g)
    {
        ClassNode node = new ClassNode { roll = r, name = n, age = a, grade = g };

        if (head == null)
        {
            head = node;
            return;
        }

        ClassNode temp = head;
        while (temp.next != null)
            temp = temp.next;

        temp.next = node;
    }

    public void DeleteByRoll(int r)
    {
        if (head == null)
            return;

        if (head.roll == r)
        {
            head = head.next;
            return;
        }

        ClassNode temp = head;
        while (temp.next != null && temp.next.roll != r)
            temp = temp.next;

        if (temp.next != null)
            temp.next = temp.next.next;
    }

    public void Search(int r)
    {
        ClassNode temp = head;

        while (temp != null)
        {
            if (temp.roll == r)
            {
                Console.WriteLine("Name: " + temp.name + ", Grade: " + temp.grade);
                return;
            }
            temp = temp.next;
        }

        Console.WriteLine("Student not found");
    }

    public void UpdateGrade(int r, char g)
    {
        ClassNode temp = head;

        while (temp != null)
        {
            if (temp.roll == r)
            {
                temp.grade = g;
                return;
            }
            temp = temp.next;
        }
    }

    public void Display()
    {
        Console.WriteLine("Student List:");
        ClassNode temp = head;

        while (temp != null)
        {
            Console.WriteLine(
                temp.roll + " " +
                temp.name + " " +
                temp.age + " " +
                temp.grade
            );
            temp = temp.next;
        }
    }
}

class Program   
{
    static void Main(string[] args)
    {
        StudentList students = new StudentList();

        students.AddAtEnd(1, "Amit", 20, 'A');
        students.AddAtEnd(2, "Neha", 21, 'B');
        students.AddAtEnd(3, "Ravi", 22, 'C');

        students.Display();

        Console.WriteLine("Searching roll no 2:");
        students.Search(2);

        Console.WriteLine("Updating grade of roll no 3:");
        students.UpdateGrade(3, 'B');
        students.Display();

        Console.WriteLine("Deleting roll no 1:");
        students.DeleteByRoll(1);
        students.Display();
    }
}
