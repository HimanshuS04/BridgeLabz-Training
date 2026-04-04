using System;

public class AddressBookManager
{
    private GlobalLinkedList addressBooks = new GlobalLinkedList();
    private IAddressBook currentAddressBook;

    public void AddAddressBook(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Address Book name cannot be empty.");
            return;
        }

        // check duplicate
        GlobalLinkedList.Node temp = addressBooks.GetHead();
        while (temp != null)
        {
            AddressBookWrapper w = (AddressBookWrapper)temp.GetData();
            if (w.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Address Book already exists.");
                return;
            }
            temp = temp.GetNext();
        }

        addressBooks.AddLast(new AddressBookWrapper(name, new AddressBookUtilityImpl()));
        Console.WriteLine($"Address Book '{name}' created successfully.");
    }

    public void DisplayAddressBookNames()
    {
        if (addressBooks.IsEmpty())
        {
            Console.WriteLine("No Address Books available.");
            return;
        }

        int i = 1;
        GlobalLinkedList.Node temp = addressBooks.GetHead();
        while (temp != null)
        {
            AddressBookWrapper w = (AddressBookWrapper)temp.GetData();
            Console.WriteLine($"{i++}. {w.Name}");
            temp = temp.GetNext();
        }
    }

    public void SelectAddressBook(string name)
    {
        GlobalLinkedList.Node temp = addressBooks.GetHead();
        while (temp != null)
        {
            AddressBookWrapper w = (AddressBookWrapper)temp.GetData();
            if (w.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                currentAddressBook = w.Book;
                Console.WriteLine($"Address Book '{name}' selected.");
                return;
            }
            temp = temp.GetNext();
        }

        Console.WriteLine("Address Book not found.");
    }

    public bool IsAddressBookSelected()
    {
        if (currentAddressBook == null)
        {
            Console.WriteLine("No Address Book selected.");
            return false;
        }
        return true;
    }

    public IAddressBook GetCurrentAddressBook()
    {
        return currentAddressBook;
    }
}
