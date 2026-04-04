using System;
class FurnitureItem : WarehouseItem
{
    public override void Display()
    {
        Console.WriteLine($"Furniture: {ItemName}, Qty: {Quantity}");
    }
}
