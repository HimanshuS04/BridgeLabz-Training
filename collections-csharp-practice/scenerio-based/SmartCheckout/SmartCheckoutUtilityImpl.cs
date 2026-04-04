using System;
using System.Collections.Generic;

public class SmartCheckoutUtilityImpl : ISmartCheckout
{
    private Queue<Customer> queue;
    private Dictionary<string, Item> itemMap;

    public SmartCheckoutUtilityImpl()
    {
        queue = new Queue<Customer>();
        itemMap = new Dictionary<string, Item>();

        // Predefined items
        itemMap.Add("Milk", new Item("Milk", 50, 10));
        itemMap.Add("Bread", new Item("Bread", 30, 15));
        itemMap.Add("Eggs", new Item("Eggs", 6, 100));
    }

    // ADD CUSTOMER WITH QUANTITY
    public void AddCustomer()
    {
        Console.Write("Enter customer name: ");
        string name = Console.ReadLine();

        Customer customer = new Customer(name);

        Console.WriteLine("Enter items (type done to stop):");
        while (true)
        {
            Console.Write("Item Name: ");
            string itemName = Console.ReadLine();

            if (itemName.Equals("done"))
                break;

            Console.Write("Quantity: ");
            int qty = int.Parse(Console.ReadLine());

            customer.GetCart().Add(new CartItem(itemName, qty));
        }

        queue.Enqueue(customer);
        Console.WriteLine("Customer added to queue.");
    }

    // process customer bill
    public void ProcessCustomer()
    {
        if (queue.Count == 0)
        {
            Console.WriteLine("No customers in queue");
            return;
        }

        Customer customer = queue.Dequeue();
        double total = 0;

        Console.WriteLine("\nBilling for " + customer.GetName());

        foreach (CartItem cartItem in customer.GetCart())
        {
            string itemName = cartItem.GetItemName();
            int qty = cartItem.GetQuantity();

            if (itemMap.ContainsKey(itemName))
            {
                Item item = itemMap[itemName];

                if (item.GetStock() >= qty)
                {
                    double cost = item.GetPrice() * qty;
                    total += cost;

                    item.SetStock(item.GetStock() - qty);

                    Console.WriteLine(itemName +
                        " x " + qty +
                        " = ₹" + cost);
                }
                else
                {
                    Console.WriteLine(itemName +
                        " insufficient stock (Available: " +
                        item.GetStock() + ")");
                }
            }
            else
            {
                Console.WriteLine(itemName + " not available");
            }
        }

        Console.WriteLine("Total Bill: ₹" + total);
    }

    public void DisplayItems()
    {
        foreach (Item item in itemMap.Values)
        {
            Console.WriteLine(item);
        }
    }
}
