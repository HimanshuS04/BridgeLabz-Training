using System;
class Rod
{
    private int length;
    private int[] prices;

    public void SetLength(int length)
    {
        this.length=length;
    }
    public int GetLength()
    {
        return length;
    }
    public void SetPrices(int[] prices)
    {
        this.prices=prices;
    }
    public int[] GetPrices()
    {
        return prices;
    }

    public override string ToString()
    {
        return $"Length {length} Prices:{prices}";
    }
}