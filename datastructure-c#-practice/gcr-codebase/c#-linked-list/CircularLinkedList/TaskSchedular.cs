using System;

class ClassNode
{
    public int id;
    public string name;
    public int priority;
    public ClassNode next;
}

class TaskScheduler
{
    ClassNode head;

    public void AddTask(int id, string name, int p)
    {
        ClassNode node = new ClassNode
        {
            id = id,
            name = name,
            priority = p
        };

        if (head == null)
        {
            head = node;
            node.next = head;
            return;
        }

        ClassNode temp = head;
        while (temp.next != head)
            temp = temp.next;

        temp.next = node;
        node.next = head;
    }

    public void Display()
    {
        if (head == null)
        {
            Console.WriteLine("No tasks available.");
            return;
        }

        ClassNode temp = head;
        do
        {
            Console.WriteLine(
                "ID: " + temp.id +
                ", Name: " + temp.name +
                ", Priority: " + temp.priority
            );
            temp = temp.next;
        } while (temp != head);
    }
}

class Program   
{
    static void Main(string[] args)
    {
        TaskScheduler scheduler = new TaskScheduler();

        scheduler.AddTask(1, "Compile Code", 1);
        scheduler.AddTask(2, "Run Tests", 2);
        scheduler.AddTask(3, "Deploy App", 3);

        Console.WriteLine("Task List:");
        scheduler.Display();
    }
}
