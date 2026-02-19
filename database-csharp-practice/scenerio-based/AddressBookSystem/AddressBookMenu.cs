using System;

public class AddressBookMenu
{
    private AddressBookManager Manager = new AddressBookManager();

    public void ShowMenu()
    {
        int choice = 0;
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nAddress Book Menu (DB only)");
            Console.WriteLine("1. Create New Address Book");
            Console.WriteLine("2. List Address Books");
            Console.WriteLine("3. Select Address Book");
            Console.WriteLine("4. Add Contact");
            Console.WriteLine("5. Add Multiple Contacts");
            Console.WriteLine("6. Display Contacts");
            Console.WriteLine("7. Edit Contact");
            Console.WriteLine("8. Delete Contact");
            Console.WriteLine("9. View Persons by City");
            Console.WriteLine("10. View Persons by State");
            Console.WriteLine("11. Count Persons by City");
            Console.WriteLine("12. Count Persons by State");
            Console.WriteLine("13. Sort Contacts by Name");
            Console.WriteLine("14. Exit");
            Console.Write("Enter your choice: ");

            string input = Console.ReadLine();

            if (!int.TryParse(input, out choice))
            {
                Console.WriteLine("Invalid input. Please enter a valid menu number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.Write("Enter Address Book Name: ");
                    string newName = Console.ReadLine();
                    Manager.AddAddressBook(newName);
                    break;

                case 2:
                    Manager.DisplayAddressBookNames();
                    break;

                case 3:
                    Manager.DisplayAddressBookNames();
                    Console.Write("Enter Address Book Name to select: ");
                    string nameToSelect = Console.ReadLine();
                    Manager.SelectAddressBook(nameToSelect);
                    break;

                case 4:
                    if (!Manager.IsAddressBookSelected()) break;
                    Manager.GetCurrentAddressBook().AddContact();
                    break;

                case 5:
                    if (!Manager.IsAddressBookSelected()) break;
                    Manager.GetCurrentAddressBook().AddMultipleContacts();
                    break;

                case 6:
                    if (!Manager.IsAddressBookSelected()) break;
                    Manager.GetCurrentAddressBook().DisplayContact();
                    break;

                case 7:
                    if (!Manager.IsAddressBookSelected()) break;
                    Manager.GetCurrentAddressBook().EditContact();
                    break;

                case 8:
                    if (!Manager.IsAddressBookSelected()) break;
                    Manager.GetCurrentAddressBook().DeleteContact();
                    break;

                case 9:
                    if (!Manager.IsAddressBookSelected()) break;
                    Manager.GetCurrentAddressBook().ViewPersonsByCity();
                    break;

                case 10:
                    if (!Manager.IsAddressBookSelected()) break;
                    Manager.GetCurrentAddressBook().ViewPersonsByState();
                    break;

                case 11:
                    if (!Manager.IsAddressBookSelected()) break;
                    Manager.GetCurrentAddressBook().CountPersonsByCity();
                    break;

                case 12:
                    if (!Manager.IsAddressBookSelected()) break;
                    Manager.GetCurrentAddressBook().CountPersonsByState();
                    break;

                case 13:
                    if (!Manager.IsAddressBookSelected()) break;
                    Manager.GetCurrentAddressBook().SortContactsByName();
                    break;

                case 14:
                    Console.WriteLine("Exiting Address Book System. Goodbye.");
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}