class ItemNode
{
    public int id;
    public string name;
    public int qty;
    public double price;
    public ItemNode next;
}

class Inventory
{
    ItemNode head;

    public void AddItem(int id, string n, int q, double p)
    {
        ItemNode node = new ItemNode { id = id, name = n, qty = q, price = p };
        node.next = head;
        head = node;
    }

    public void UpdateQty(int id, int q)
    {
        ItemNode temp = head;
        while (temp != null)
        {
            if (temp.id == id) { temp.qty = q; return; }
            temp = temp.next;
        }
    }

    public double TotalValue()
    {
        double sum = 0;
        ItemNode temp = head;
        while (temp != null)
        {
            sum += temp.qty * temp.price;
            temp = temp.next;
        }
        return sum;
    }
}
