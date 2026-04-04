using System;
class GroceryItem : WarehouseItem
{
    public override void Display()
    {
        Console.WriteLine($"Grocery: {ItemName}, Qty: {Quantity}");
    }
}
