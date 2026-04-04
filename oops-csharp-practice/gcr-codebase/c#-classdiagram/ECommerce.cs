using System;

class Product
{
    public string ProductName;
}

class Order
{
    public List<Product> Products = new List<Product>();

    public void ShowProducts()
    {
        Console.WriteLine("Order contains:");
        foreach (var p in Products)
            Console.WriteLine(p.ProductName);
    }
}

class CustomerData
{
    public string Name;

    public void PlaceOrder(Order order)
    {
        Console.WriteLine($"{Name} placed an order");
        order.ShowProducts();
    }
}

class Program
{
    static void Main()
    {
        CustomerData c = new CustomerData { Name = "Arvind" };

        Order o = new Order();
        o.Products.Add(new Product { ProductName = "Laptop" });
        o.Products.Add(new Product { ProductName = "Mouse" });
        o.Products.Add(new Product { ProductName = "Keyboard" });

        c.PlaceOrder(o);
    }
}
