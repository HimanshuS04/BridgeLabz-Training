//sort stack using recursion
using System;

class MyStack
{
    static int[] stack = new int[10]; 
    static int top = -1;

    static void Push(int x)
    {
        stack[++top] = x;
    }
    static int Pop()
    {
        return stack[top--];
    }
    static bool IsEmpty()
    {
        return top == -1;
    }
    static int Peek()
    {
        return stack[top];
    }

  
    static void PrintStack()
    {
        for (int i = top; i >= 0; i--)
            Console.Write(stack[i] + " ");
        Console.WriteLine();
    }

    static void SortStack()
    {
        if (!IsEmpty())
        {
            int temp = Pop();      
            SortStack();          
            InsertSorted(temp);  
    }
    }

    static void InsertSorted(int x)
    {
        if (IsEmpty() || Peek() <= x)
        {
            Push(x);
            return;
        }

        int temp = Pop();
        InsertSorted(x);
        Push(temp);
    }
    static void Main(String[] args)
    {
        Push(3);
        Push(1);
        Push(4);
        Push(2);

        Console.WriteLine("Before Sorting--");
        PrintStack();

        SortStack();

        Console.WriteLine("After Sorting--");
        PrintStack();
    }
}
