using System;

public class AddressBookMenu
{
    private AddressBookManager Manager = new AddressBookManager();

    public void ShowMenu()
    {
        int choice;
        do
        {
            Console.WriteLine("\nAddress Book Menu");
            Console.WriteLine("1. Create New Address Book");
            Console.WriteLine("2. Select Address Book");
            Console.WriteLine("3. Add Contact");
            Console.WriteLine("4. Add Multiple Contacts");
            Console.WriteLine("5. Display Contacts");
            Console.WriteLine("6. Edit Contact");
            Console.WriteLine("7. Delete Contact");
            Console.WriteLine("8. Search Person by City (Current Address Book)");
            Console.WriteLine("9. Search Person by State (Current Address Book)");
            Console.WriteLine("10. Exit");
            Console.Write("Enter your choice: ");
            choice = int.Parse(Console.ReadLine());

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
                    Manager.GetCurrentAddressBook().SearchPersonByCity();
                    break;

                case 9:
                    if (!Manager.IsAddressBookSelected()) break;
                    Manager.GetCurrentAddressBook().SearchPersonByState();
                    break;

                case 10:
                    Console.WriteLine("Exiting Address Book System. Goodbye.");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        } while (choice != 10);
    }
}