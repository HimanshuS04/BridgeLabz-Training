using System;

class ClassNode
{
    public int id;
    public string name;
    public int qty;
    public double price;
    public ClassNode next;
}

class Inventory
{
    ClassNode head;

    public void AddItem(int id, string n, int q, double p)
    {
        ClassNode node = new ClassNode
        {
            id = id,
            name = n,
            qty = q,
            price = p
        };

        node.next = head;
        head = node;
    }

    public void UpdateQty(int id, int q)
    {
        ClassNode temp = head;
        while (temp != null)
        {
            if (temp.id == id)
            {
                temp.qty = q;
                return;
            }
            temp = temp.next;
        }
    }

    public double TotalValue()
    {
        double sum = 0;
        ClassNode temp = head;

        while (temp != null)
        {
            sum += temp.qty * temp.price;
            temp = temp.next;
        }

        return sum;
    }

    public void DisplayItems()
    {
        Console.WriteLine("Inventory Items:");
        ClassNode temp = head;

        while (temp != null)
        {
            Console.WriteLine(
                "ID: " + temp.id +
                ", Name: " + temp.name +
                ", Qty: " + temp.qty +
                ", Price: " + temp.price
            );
            temp = temp.next;
        }
    }
}

class Program   // 👈 Main class
{
    static void Main(string[] args)
    {
        Inventory inv = new Inventory();

        inv.AddItem(1, "Pen", 10, 5.0);
        inv.AddItem(2, "Notebook", 5, 50.0);
        inv.AddItem(3, "Marker", 3, 30.0);

        inv.DisplayItems();

        Console.WriteLine("\nUpdating quantity of item ID 2...\n");
        inv.UpdateQty(2, 8);

        inv.DisplayItems();

        double total = inv.TotalValue();
        Console.WriteLine("\nTotal Inventory Value: " + total);
    }
}
