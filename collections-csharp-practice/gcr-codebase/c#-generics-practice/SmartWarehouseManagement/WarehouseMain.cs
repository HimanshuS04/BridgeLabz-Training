using System;
using System.Data.SqlTypes;
class WarehouseMain
{
    static void Main()
    {
        Storage<ElectronicsItem> electronics = new Storage<ElectronicsItem>();
        electronics.AddItem(new ElectronicsItem { ItemName = "Laptop", Quantity = 5 });
        Storage<GroceryItem> groceries = new Storage<GroceryItem>();
        groceries.AddItem(new GroceryItem {ItemName = "Rice", Quantity = 10});
        electronics.ShowAllItems();
        groceries.ShowAllItems();
    }
}
