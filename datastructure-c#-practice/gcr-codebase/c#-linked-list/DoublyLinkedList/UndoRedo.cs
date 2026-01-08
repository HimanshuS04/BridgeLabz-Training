class TextNode
{
    public string text;
    public TextNode prev, next;
}

class TextEditor
{
    TextNode current;

    public void AddState(string t)
    {
        TextNode node = new TextNode { text = t };
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
    }
}
