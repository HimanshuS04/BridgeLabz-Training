using System;

class ClassNode
{
    public int id;
    public string name;
    public ClassNode next;
}

class SocialMedia
{
    ClassNode head;

    public void AddUser(int id, string name)
    {
        ClassNode node = new ClassNode
        {
            id = id,
            name = name
        };

        node.next = head;
        head = node;
    }

    public void SearchUser(int id)
    {
        ClassNode temp = head;

        while (temp != null)
        {
            if (temp.id == id)
            {
                Console.WriteLine("User Found: " + temp.name);
                return;
            }
            temp = temp.next;
        }

        Console.WriteLine("User not found.");
    }

    public void DisplayUsers()
    {
        Console.WriteLine("All Users:");
        ClassNode temp = head;

        while (temp != null)
        {
            Console.WriteLine("ID: " + temp.id + ", Name: " + temp.name);
            temp = temp.next;
        }
    }
}

class Program  
{
    static void Main(string[] args)
    {
        SocialMedia sm = new SocialMedia();

        sm.AddUser(1, "Sourabh");
        sm.AddUser(2, "Bobby");
        sm.AddUser(3, "Chirag");

        sm.DisplayUsers();

        Console.WriteLine("Searching for user with ID 2:");
        sm.SearchUser(2);

        Console.WriteLine("Searching for user with ID 5:");
        sm.SearchUser(5);
    }
}
