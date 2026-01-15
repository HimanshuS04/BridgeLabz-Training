using System;

public class AddressBookMenu
{
    private IAddressBook Utility=new AddressBookUtilityImpl();

    public void ShowMenu()
    {
        int choice;
        do
        {
            Console.WriteLine("\nAddress Book Menu");
            Console.WriteLine("1. Add Contact");
            Console.WriteLine("2. Display Contact");
            Console.WriteLine("3. Edit Contact");
            Console.WriteLine("4. Delete Contact");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
            choice=int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Utility.AddContact();
                    break;
                case 2:
                    Utility.DisplayContact();
                    break;
                case 3:
                    Utility.EditContact();
                    break;
                case 4:
                    Utility.DeleteContact();
                    break;
                case 5:
                    Console.WriteLine("Exiting Address Book. Goodbye.");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        } while(choice!=5);
    }
}