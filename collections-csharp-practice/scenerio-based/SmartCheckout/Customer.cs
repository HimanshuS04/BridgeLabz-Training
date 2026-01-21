using System.Collections.Generic;

public class Customer
{
    private string name;
    private List<CartItem> cart;

    public Customer(string name)
    {
        this.name = name;
        cart = new List<CartItem>();
    }

    public string GetName() { return name; }
    public void SetName(string name) { this.name = name; }

    public List<CartItem> GetCart() { return cart; }
}
