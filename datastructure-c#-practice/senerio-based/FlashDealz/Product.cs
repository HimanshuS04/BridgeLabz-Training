using System;
public class Product
{
    private string Name;
    private int Discount;

    public void SetProduct(string name, int discount)
    {
        Name = name;
        Discount = discount;
    }
    public string GetName()
    {
        return Name;
    }
    public int GetDiscount()
    {
        return Discount;
    }
    public override string ToString()
    {
        return $"Product: {Name}, Discount: {Discount}";
    }
}