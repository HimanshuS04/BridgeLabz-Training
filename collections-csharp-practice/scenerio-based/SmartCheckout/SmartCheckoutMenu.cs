using System;

public class SmartCheckoutMenu
{
    private ISmartCheckout checkout = new SmartCheckoutUtilityImpl();

    public void ShowMenu()
    {
        int choice;
        do
        {
            Console.WriteLine("1. Add Customer");
            Console.WriteLine("2. Process Customer");
            Console.WriteLine("3. Display Items");
            Console.WriteLine("4. Exit");
            Console.Write("Enter choice: ");

            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    checkout.AddCustomer();
                    break;
                case 2:
                    checkout.ProcessCustomer();
                    break;
                case 3:
                    checkout.DisplayItems();
                    break;
            }

        } while (choice != 4);
    }
}
