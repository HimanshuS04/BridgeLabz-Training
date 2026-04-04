using System;
public class Item
{
    private string Name;
    private double Price;
    private int Stock;
    public Item(string name, double price, int stock)
    {
        Name = name;
        Price = price;
        Stock = stock;
    }
    public string GetName()
    {
        return Name;
    }
    public void SetName(string name)
    {
        Name = name;
    }
    public double GetPrice()
    {
        return Price;
    }
    public void SetPrice(double price)
    {
        Price = price;
    }
    public int GetStock()
    {
        return Stock;
    }
    public void SetStock(int stock)
    {
        Stock = stock;
    }
    public override string ToString()
    {
        return Name + " | ₹" + Price + " | Stock: " + Stock;
    }
}