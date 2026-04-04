using System;

class Node
{
    public int Key;
    public int Value;
    public Node Next;

    public Node(int k, int v)
    {
        Key = k;
        Value = v;
        Next = null;
    }
}

class HashMapArrayLinkedList
{
    Node[] table = new Node[10];

    int Hash(int Key)
    {
        return Key % table.Length;
    }

    public void Put(int Key, int Value)
    {
        int index = Hash(Key);
        Node head = table[index];

        while (head != null)
        {
            if (head.Key == Key)
            {
                head.Value = Value;
                return;
            }
            head = head.Next;
        }

        Node newNode = new Node(Key, Value);
        newNode.Next = table[index];
        table[index] = newNode;
    }

    public int Get(int Key)
    {
        int index = Hash(Key);
        Node head = table[index];

        while (head != null)
        {
            if (head.Key == Key)
                return head.Value;
            head = head.Next;
        }
        return -1;
    }

    public void Remove(int Key)
    {
        int index = Hash(Key);
        Node head = table[index];
        Node prev = null;

        while (head != null)
        {
            if (head.Key == Key)
            {
                if (prev == null)
                    table[index] = head.Next;
                else
                    prev.Next = head.Next;
                return;
            }
            prev = head;
            head = head.Next;
        }
    }
}

class Program
{
    static void Main()
    {
        CustomHashMap map = new CustomHashMap();
        map.Put(1, 100);
        map.Put(2, 200);
        map.Put(11, 300);

        Console.WriteLine(map.Get(1));
        Console.WriteLine(map.Get(11));

        map.Remove(1);
        Console.WriteLine(map.Get(1));
    }
}
