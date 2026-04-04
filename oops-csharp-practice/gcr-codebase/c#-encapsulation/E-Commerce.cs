using System;

interface ITaxable
{
    double CalculateTax();
    string GetTaxDetails();
}

abstract class Product
{
    protected int productId;
    protected string name;
    protected double price;

    public Product(int id, string name, double price)
    {
        productId = id;
        this.name = name;
        this.price = price;
    }

    public abstract double CalculateDiscount();

    public double CalculateFinalPrice()
    {
        double tax = 0;
        if (this is ITaxable)
            tax = ((ITaxable)this).CalculateTax();

        return price + tax - CalculateDiscount();
    }
}

class Electronics : Product, ITaxable
{
    public Electronics(int id, string name, double price)
        : base(id, name, price) { }

    public override double CalculateDiscount()
    {
        return price * 0.10;
    }

    public double CalculateTax()
    {
        return price * 0.18;
    }

    public string GetTaxDetails()
    {
        return "18% GST";
    }
}

class Clothing : Product
{
    public Clothing(int id, string name, double price)
        : base(id, name, price) { }

    public override double CalculateDiscount()
    {
        return price * 0.20;
    }
}

class Program
{
    static void Main()
    {
        Product[] products = new Product[2];
        products[0] = new Electronics(1, "Mac", 100000);
        products[1] = new Clothing(2, "Shirt", 2000);

        for (int i = 0; i < products.Length; i++)
            Console.WriteLine("Final Price: " + products[i].CalculateFinalPrice());
    }
}
