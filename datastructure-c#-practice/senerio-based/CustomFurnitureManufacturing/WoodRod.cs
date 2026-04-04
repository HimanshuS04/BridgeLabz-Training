public class WoodRod
{
    private int Length;
    private int Price;

    public void SetLength(int length)
    {
        Length = length;
    }

    public int GetLength()
    {
        return Length;
    }

    public void SetPrice(int price)
    {
        Price = price;
    }

    public int GetPrice()
    {
        return Price;
    }

    public int GetRevenue()
    {
        return Length * Price;
    }

    public override string ToString()
    {
        return $"Length: {Length} ft | Price: ₹{Price}";
    }
}
