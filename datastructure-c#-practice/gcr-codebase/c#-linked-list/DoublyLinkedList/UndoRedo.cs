using System;

class ClassNode
{
    public string text;
    public ClassNode prev, next;
}

class TextEditor
{
    ClassNode current;

    public void AddState(string t)
    {
        ClassNode node = new ClassNode { text = t };

        if (current != null)
        {
            current.next = node;
            node.prev = current;
        }

        current = node;
    }

    public void Undo()
    {
        if (current != null && current.prev != null)
            current = current.prev;
    }

    public void Redo()
    {
        if (current != null && current.next != null)
            current = current.next;
    }

    public void Display()
    {
        if (current != null)
            Console.WriteLine("Current Text: " + current.text);
        else
            Console.WriteLine("Editor is empty.");
    }
}

class Program   
{
    static void Main(string[] args)
    {
        TextEditor editor = new TextEditor();

        editor.AddState("Hello");
        editor.Display();

        editor.AddState("Hello World");
        editor.Display();

        editor.AddState("Hello World!");
        editor.Display();

        Console.WriteLine("\nUndo:");
        editor.Undo();
        editor.Display();

        Console.WriteLine("\nUndo:");
        editor.Undo();
        editor.Display();

        Console.WriteLine("\nRedo:");
        editor.Redo();
        editor.Display();
    }
}
