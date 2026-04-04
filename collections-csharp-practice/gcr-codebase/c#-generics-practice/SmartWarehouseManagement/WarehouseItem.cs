using System;
public abstract class WarehouseItem
{
    public string ItemName { get; set; }
    public int Quantity { get; set; }

    public abstract void Display();
}
