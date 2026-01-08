using System;

class StudentNode
{
    public int roll;
    public string name;
    public int age;
    public char grade;
    public StudentNode next;
}

class StudentList
{
    StudentNode head;

    public void AddAtEnd(int r, string n, int a, char g)
    {
        StudentNode node = new StudentNode { roll = r, name = n, age = a, grade = g };
        if (head == null) { head = node; return; }

        StudentNode temp = head;
        while (temp.next != null) temp = temp.next;
        temp.next = node;
    }

    public void DeleteByRoll(int r)
    {
        if (head == null) return;
        if (head.roll == r) { head = head.next; return; }

        StudentNode temp = head;
        while (temp.next != null && temp.next.roll != r)
            temp = temp.next;

        if (temp.next != null)
            temp.next = temp.next.next;
    }

    public void Search(int r)
    {
        StudentNode temp = head;
        while (temp != null)
        {
            if (temp.roll == r)
            {
                Console.WriteLine(temp.name + " Grade: " + temp.grade);
                return;
            }
            temp = temp.next;
        }
        Console.WriteLine("Student not found");
    }

    public void UpdateGrade(int r, char g)
    {
        StudentNode temp = head;
        while (temp != null)
        {
            if (temp.roll == r) { temp.grade = g; return; }
            temp = temp.next;
        }
    }

    public void Display()
    {
        StudentNode temp = head;
        while (temp != null)
        {
            Console.WriteLine(temp.roll + " " + temp.name + " " + temp.grade);
            temp = temp.next;
        }
    }
}
