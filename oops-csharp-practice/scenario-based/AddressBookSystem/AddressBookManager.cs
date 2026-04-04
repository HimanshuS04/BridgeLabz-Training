using System;

public class AddressBookManager
{
    private string[] AddressBookNames = new string[10];
    private IAddressBook[] AddressBooks = new IAddressBook[10];
    private int AddressBookCount = 0;
    private IAddressBook CurrentAddressBook;
// add new address book 
    public void AddAddressBook(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Address Book name cannot be empty.");
            return;
        }

        // Check uniqueness (case-insensitive)
        for (int i = 0; i < AddressBookCount; i++)
        {
            if (string.Equals(AddressBookNames[i], name, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("An Address Book with this name already exists.");
                return;
            }
        }

        if (AddressBookCount >= AddressBooks.Length)
        {
            Console.WriteLine("Cannot add more Address Books. Limit reached.");
            return;
        }

        AddressBookNames[AddressBookCount] = name;
        AddressBooks[AddressBookCount] = new AddressBookUtilityImpl();
        AddressBookCount++;

        Console.WriteLine("Address Book '" + name + "' created successfully.");
    }
// find the particular address book
    public IAddressBook GetAddressBook(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return null;
        }

        for (int i = 0; i < AddressBookCount; i++)
        {
            if (string.Equals(AddressBookNames[i], name, StringComparison.OrdinalIgnoreCase))
            {
                return AddressBooks[i];
            }
        }

        return null;
    }

    public void DisplayAddressBookNames()
    {
        if (AddressBookCount == 0)
        {
            Console.WriteLine("No Address Books available.");
            return;
        }

        Console.WriteLine("Available Address Books:");
        for (int i = 0; i < AddressBookCount; i++)
        {
            Console.WriteLine((i + 1) + ". " + AddressBookNames[i]);
        }
    }

    // select a current address book by name
    public void SelectAddressBook(string name)
    {
        IAddressBook book = GetAddressBook(name);
        if (book == null)
        {
            Console.WriteLine("Address Book not found.");
            CurrentAddressBook = null;
            return;
        }

        CurrentAddressBook = book;
        Console.WriteLine("Address Book '" + name + "' selected.");
    }
//check wheter address book is selected or not 
    public bool IsAddressBookSelected()
    {
        if (CurrentAddressBook == null)
        {
            Console.WriteLine("No Address Book selected.");
            return false;
        }
        return true;
    }

    //  getter for the currently selected address book
    public IAddressBook GetCurrentAddressBook()
    {
        return CurrentAddressBook;
    }
}