using System;
public class ElectronicsItem : WarehouseItem
{
    public override void Display()
    {
        Console.WriteLine($"Electronics: {ItemName}, Qty: {Quantity}");
    }
}
