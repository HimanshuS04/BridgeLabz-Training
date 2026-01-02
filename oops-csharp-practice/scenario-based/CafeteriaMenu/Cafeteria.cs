using System;

class Cafeteria
{
    Item[] menu;

    public Cafeteria()
    {
        menu = new Item[]
        {
            new Item("Idli", 40),
            new Item("Dosa", 60),
            new Item("Pav Bhaji", 80),
            new Item("Veg Biryani", 120),
            new Item("Fried Rice", 100),
            new Item("Sandwich", 50),
            new Item("Burger", 70),
            new Item("Pizza", 150),
            new Item("Noodles", 90),
            new Item("Samosa", 20)
        };
    }

    // Common menu display
    public void DisplayMenu()
    {
        Console.WriteLine("Cafeteria Menu ");
        for (int i = 0; i < menu.Length; i++)
        {
            Console.WriteLine(i + " : " + menu[i].Name + " - ₹" + menu[i].Price);
        }
    }

    // Owner view
    public void OwnerMenu()
    {
        Console.WriteLine("Owner View ");
        DisplayMenu();
        Console.WriteLine("Total items: " + menu.Length);
    }

    // Customer ordering
    public int CustomerMenu()
    {
        int totalBill = 0;
        char choice;

        do
        {
            DisplayMenu();

            Console.Write("Enter item index to order: ");
            int index = int.Parse(Console.ReadLine());

            if (index >= 0 && index < menu.Length)
            {
                totalBill += menu[index].Price;
                Console.WriteLine("Added: " + menu[index].Name);
            }
            else
            {
                Console.WriteLine("Invalid selection!");
            }

            Console.Write("Order more? (y/n): ");
            choice = Char.Parse(Console.ReadLine());

        } while (choice == 'y' || choice == 'Y');

        return totalBill;
    }
}
