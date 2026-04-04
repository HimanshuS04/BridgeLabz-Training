using System;
public class CartItem
{
    private string itemName;
    private int quantity;

    public CartItem(string itemName, int quantity)
    {
        this.itemName = itemName;
        this.quantity = quantity;
    }

    public string GetItemName() { return itemName; }
    public void SetItemName(string itemName) { this.itemName = itemName; }

    public int GetQuantity() { return quantity; }
    public void SetQuantity(int quantity) { this.quantity = quantity; }
    public override string ToString()
    {
        return $"Item Name:{itemName} Quantity{quantity}";
    }
}
