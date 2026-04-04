using System;
using System.Collections.Generic;

public class AddressBookManager
{
    private Dictionary<string, IAddressBook> AddressBooks =
        new Dictionary<string, IAddressBook>(StringComparer.OrdinalIgnoreCase);

    private IAddressBook CurrentAddressBook;
    private string CurrentAddressBookName;

    public void AddAddressBook(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new InvalidAddressBookNameException();
        }

        if (AddressBooks.ContainsKey(name))
        {
            throw new DuplicateAddressBookException(name);
        }

        AddressBooks[name] = new AddressBookUtilityImpl();
        Console.WriteLine("Address Book '" + name + "' created successfully.");

        // Auto-select newly created book
        CurrentAddressBook = AddressBooks[name];
        CurrentAddressBookName = name;
        Console.WriteLine("Address Book '" + name + "' is now selected.");
    }

    public IAddressBook GetAddressBook(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return null;
        }

        IAddressBook book;
        if (AddressBooks.TryGetValue(name, out book))
        {
            return book;
        }

        return null;
    }

    public void DisplayAddressBookNames()
    {
        if (AddressBooks.Count == 0)
        {
            Console.WriteLine("No Address Books available.");
            return;
        }

        Console.WriteLine("Available Address Books:");
        int index = 1;
        foreach (string name in AddressBooks.Keys)
        {
            Console.WriteLine(index + ". " + name);
            index++;
        }
    }

    public void SelectAddressBook(string name)
    {
        IAddressBook book = GetAddressBook(name);
        if (book == null)
        {
            throw new AddressBookNotFoundException(name);
        }

        CurrentAddressBook = book;
        CurrentAddressBookName = name;
        Console.WriteLine("Address Book '" + name + "' selected.");
    }

    public bool IsAddressBookSelected()
    {
        if (CurrentAddressBook == null)
        {
            Console.WriteLine("No Address Book selected. Please create or select an Address Book first.");
            return false;
        }
        return true;
    }

    public IAddressBook GetCurrentAddressBook()
    {
        return CurrentAddressBook;
    }
}