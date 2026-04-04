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
            Console.WriteLine("\nAddress Book Menu");
            Console.WriteLine("1. Create New Address Book");
            Console.WriteLine("2. Select Address Book");
            Console.WriteLine("3. Add Contact");
            Console.WriteLine("4. Add Multiple Contacts");
            Console.WriteLine("5. Display Contacts");
            Console.WriteLine("6. Edit Contact");
            Console.WriteLine("7. Delete Contact");
            Console.WriteLine("8. View Persons by City (Current Address Book)");
            Console.WriteLine("9. View Persons by State (Current Address Book)");
            Console.WriteLine("10. Count Persons by City (Current Address Book)");
            Console.WriteLine("11. Count Persons by State (Current Address Book)");
            Console.WriteLine("12. Sort Contacts by Name (Current Address Book)");
            Console.WriteLine("13. Exit");
            Console.Write("Enter your choice: ");

            string input = Console.ReadLine();

            try
            {
                choice = int.Parse(input);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid menu number.");
                continue;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Number is too large. Please enter a smaller menu number.");
                continue;
            }

            try
            {
                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Address Book Name: ");
                        string newName = Console.ReadLine();
                        Manager.AddAddressBook(newName);
                        break;

                    case 2:
                        Manager.DisplayAddressBookNames();
                        Console.Write("Enter Address Book Name to select: ");
                        string nameToSelect = Console.ReadLine();
                        Manager.SelectAddressBook(nameToSelect);
                        break;

                    case 3:
                        if (!Manager.IsAddressBookSelected()) break;
                        Manager.GetCurrentAddressBook().AddContact();
                        break;

                    case 4:
                        if (!Manager.IsAddressBookSelected()) break;
                        Manager.GetCurrentAddressBook().AddMultipleContacts();
                        break;

                    case 5:
                        if (!Manager.IsAddressBookSelected()) break;
                        Manager.GetCurrentAddressBook().DisplayContact();
                        break;

                    case 6:
                        if (!Manager.IsAddressBookSelected()) break;
                        Manager.GetCurrentAddressBook().EditContact();
                        break;

                    case 7:
                        if (!Manager.IsAddressBookSelected()) break;
                        Manager.GetCurrentAddressBook().DeleteContact();
                        break;

                    case 8:
                        if (!Manager.IsAddressBookSelected()) break;
                        Manager.GetCurrentAddressBook().ViewPersonsByCity();
                        break;

                    case 9:
                        if (!Manager.IsAddressBookSelected()) break;
                        Manager.GetCurrentAddressBook().ViewPersonsByState();
                        break;

                    case 10:
                        if (!Manager.IsAddressBookSelected()) break;
                        Manager.GetCurrentAddressBook().CountPersonsByCity();
                        break;

                    case 11:
                        if (!Manager.IsAddressBookSelected()) break;
                        Manager.GetCurrentAddressBook().CountPersonsByState();
                        break;

                    case 12:
                        if (!Manager.IsAddressBookSelected()) break;
                        Manager.GetCurrentAddressBook().SortContactsByName();
                        break;

                    case 13:
                        Console.WriteLine("Exiting Address Book System. Goodbye.");
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            catch (AddressBookException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}