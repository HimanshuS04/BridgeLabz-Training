using System;

class Stack
{
    int[] arr = new int[50];
    int top = -1;

    public void Push(int x) { arr[++top] = x; }
    public int Pop() { return arr[top--]; }
    public bool IsEmpty() { return top == -1; }
}

class QueueUsingStacks
{
    Stack s1 = new Stack();
    Stack s2 = new Stack();

    public void Enqueue(int x) { s1.Push(x); }

    public int Dequeue()
    {
        if (s2.IsEmpty())
            while (!s1.IsEmpty())
                s2.Push(s1.Pop());
        return s2.Pop();
    }
}

class Program
{
    static void Main()
    {
        QueueUsingStacks q = new QueueUsingStacks();
        q.Enqueue(10);
        q.Enqueue(20);
        q.Enqueue(30);

        Console.WriteLine(q.Dequeue());
        Console.WriteLine(q.Dequeue());
    }
}
