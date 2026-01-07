using System;

interface IDiscountable
{
    double ApplyDiscount();
    string GetDiscountDetails();
}

abstract class FoodItem
{
    protected string itemName;
    protected double price;
    protected int quantity;

    public FoodItem(string name, double price, int qty)
    {
        itemName = name;
        this.price = price;
        quantity = qty;
    }

    public abstract double CalculateTotalPrice();
}

class VegItem : FoodItem, IDiscountable
{
    public VegItem(string name, double price, int qty)
        : base(name, price, qty) { }

    public override double CalculateTotalPrice()
    {
        return price * quantity;
    }

    public double ApplyDiscount()
    {
        return 50;
    }

    public string GetDiscountDetails()
    {
        return "Flat ₹50 Off";
    }
}
