using System;

public class AddressBookMenu
{
    private IAddressBook Utility = new AddressBookUtilityImpl();

    public void ShowMenu()
    {
        int choice;
        do
        {
            Console.WriteLine("\nAddress Book Menu");
            Console.WriteLine("1. Add Contact");
            Console.WriteLine("2. Add Multiple Contacts");
            Console.WriteLine("3. Display Contact");
            Console.WriteLine("4. Edit Contact");
            Console.WriteLine("5. Delete Contact");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Utility.AddContact();
                    break;
                case 2:
                    Utility.AddMultipleContacts();
                    break;
                case 3:
                    Utility.DisplayContact();
                    break;
                case 4:
                    Utility.EditContact();
                    break;
                case 5:
                    Utility.DeleteContact();
                    break;
                case 6:
                    Console.WriteLine("Exiting Address Book. Goodbye.");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        } while (choice != 6);
    }
}