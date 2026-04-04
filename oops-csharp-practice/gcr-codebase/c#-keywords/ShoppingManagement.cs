using System;

class ShoppingManagement
{
    public static int Discount = 10;
    public readonly int ShoppingID;
    public string ShoppingName;
    public double Price;
    public int Quantity;

    public ShoppingManagement(string ShoppingName, double Price, int Quantity, int ShoppingID)
    {
        this.ShoppingName = ShoppingName;
        this.Price = Price;
        this.Quantity = Quantity;
        this.ShoppingID = ShoppingID;
    }

    public static void UpdateDiscount(int newDiscount)
    {
        Discount = newDiscount;
    }

    public void Display(object obj)
    {
        if (obj is ShoppingManagement)
        {
            Console.WriteLine(ShoppingName + " - ₹" + Price);
        }
    }
}

class Program
{
    static void Main()
    {
        ShoppingManagement p1 = new ShoppingManagement("Laptop", 50000, 1, 101);
        p1.Display(p1);
        ShoppingManagement.UpdateDiscount(20);
    }
}
