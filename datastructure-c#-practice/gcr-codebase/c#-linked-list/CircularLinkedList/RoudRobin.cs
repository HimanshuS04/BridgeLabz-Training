using System;

class ClassNode
{
    public int pid, burst;
    public ClassNode next;
}

class RoundRobin
{
    ClassNode head;

    public void AddProcess(int pid, int burst)
    {
        ClassNode node = new ClassNode { pid = pid, burst = burst };

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

    public void Simulate(int tq)
    {
        if (head == null)
        {
            Console.WriteLine("No processes to execute.");
            return;
        }

        ClassNode temp = head;

        do
        {
            Console.WriteLine("Executing P" + temp.pid);

            temp.burst -= tq;
            if (temp.burst < 0)
                temp.burst = 0;

            Console.WriteLine("Remaining Burst: " + temp.burst);

            temp = temp.next;

        } while (temp != head);
    }
}

class Program
{
    static void Main(string[] args)
    {
        RoundRobin rr = new RoundRobin();

        rr.AddProcess(1, 10);
        rr.AddProcess(2, 8);
        rr.AddProcess(3, 6);

        Console.Write("Enter Time Quantum: ");
        int tq = int.Parse(Console.ReadLine());

        rr.Simulate(tq);

        Console.WriteLine("Execution completed.");
    }
}
