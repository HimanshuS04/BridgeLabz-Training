using System;
using System.Collections.Generic;

public class AddressBookManager
{
    private Dictionary<string, IAddressBook> AddressBooks =
        new Dictionary<string, IAddressBook>(StringComparer.OrdinalIgnoreCase);

    private IAddressBook CurrentAddressBook;
    private string CurrentAddressBookName;

    private readonly AddressBookRepository Repository;

    public AddressBookManager()
    {
        Repository = new AddressBookRepository(DatabaseConfig.ConnectionString);
    }

    public void AddAddressBook(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Address Book name cannot be empty.");
            return;
        }

        if (AddressBooks.ContainsKey(name))
        {
            Console.WriteLine("Address Book already exists in memory (for this run).");
            return;
        }

        int id;
        try
        {
            id = Repository.CreateAddressBook(name, null);
        }
        catch (Microsoft.Data.SqlClient.SqlException ex) when (ex.Number == 2627)
        {
            Console.WriteLine("Address Book with this name already exists in the database.");
            return;
        }

        IAddressBook book = new AddressBookUtilityImpl(id, Repository);
        AddressBooks[name] = book;

        CurrentAddressBook = book;
        CurrentAddressBookName = name;

        Console.WriteLine($"Address Book '{name}' created with Id={id} and selected.");
    }

    public void DisplayAddressBookNames()
    {
        var dbBooks = Repository.GetAddressBooks();
        if (dbBooks.Count == 0)
        {
            Console.WriteLine("No Address Books in database.");
            return;
        }

        Console.WriteLine("Address Books (from DB):");
        foreach (var b in dbBooks)
        {
            Console.WriteLine($"Id={b.AddressBookId}, Name={b.Name}, Description={b.Description}");
        }
    }

    public void SelectAddressBook(string name)
    {
        int? id = Repository.GetAddressBookIdByName(name);
        if (!id.HasValue)
        {
            Console.WriteLine("Address Book not found in database.");
            return;
        }

        // reuse existing instance in memory if present
        if (!AddressBooks.TryGetValue(name, out CurrentAddressBook))
        {
            CurrentAddressBook = new AddressBookUtilityImpl(id.Value, Repository);
            AddressBooks[name] = CurrentAddressBook;
        }

        CurrentAddressBookName = name;
        Console.WriteLine($"Address Book '{name}' selected (Id={id.Value}).");
    }

    public bool IsAddressBookSelected()
    {
        if (CurrentAddressBook == null)
        {
            Console.WriteLine("No Address Book selected.");
            return false;
        }
        return true;
    }

    public IAddressBook GetCurrentAddressBook()
    {
        return CurrentAddressBook;
    }
}