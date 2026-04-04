using System;

public class FlashDealzMenu
{
    private IFlashDealz service;

    public FlashDealzMenu()
    {
        service = new FlashDealzUtilityImpl();
    }

    public void Start()
    {
        int choice;

        do
        {
            Console.WriteLine("===== FlashDealz Menu =====");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Sort Products By Discount");
            Console.WriteLine("3. Display Products");
            Console.WriteLine("4. Exit");
            Console.Write("Enter choice: ");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    service.AddProduct();
                    break;

                case 2:
                    service.SortByDiscount();
                    break;

                case 3:
                    service.DisplayProducts();
                    break;

                case 4:
                    Console.WriteLine("Exiting...");
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

        } while (choice != 4);
    }
}
