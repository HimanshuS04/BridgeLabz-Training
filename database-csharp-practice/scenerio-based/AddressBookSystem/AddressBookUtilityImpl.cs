using System;
using System.Collections.Generic;

public class AddressBookUtilityImpl : IAddressBook
{
    private readonly int AddressBookId;
    private readonly AddressBookRepository Repository;

    public AddressBookUtilityImpl(int addressBookId, AddressBookRepository repository)
    {
        AddressBookId = addressBookId;
        Repository = repository;
    }

    private void TakeContactInput(Contact contact)
    {
        Console.Write("Enter First Name: ");
        contact.SetFirstName(Console.ReadLine());

        Console.Write("Enter Last Name: ");
        contact.SetLastName(Console.ReadLine());

        Console.Write("Enter Address: ");
        contact.SetAddress(Console.ReadLine());

        Console.Write("Enter City: ");
        contact.SetCity(Console.ReadLine());

        Console.Write("Enter State: ");
        contact.SetState(Console.ReadLine());

        Console.Write("Enter Zip: ");
        contact.SetZip(Console.ReadLine());

        Console.Write("Enter Phone Number: ");
        contact.SetPhoneNumber(Console.ReadLine());

        Console.Write("Enter Email: ");
        contact.SetEmail(Console.ReadLine());
    }

    public void AddContact()
    {
        Contact contact = new Contact();
        TakeContactInput(contact);
        Repository.AddContact(AddressBookId, contact);
    }

    public void AddMultipleContacts()
    {
        Console.Write("How many contacts do you want to add? ");
        if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
        {
            Console.WriteLine("Invalid number.");
            return;
        }

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nEntering details for contact {i + 1}:");
            AddContact();
        }
    }

    public void DisplayContact()
    {
        List<Contact> contacts = Repository.GetContactsByAddressBook(AddressBookId);

        if (contacts.Count == 0)
        {
            Console.WriteLine("No contacts to display.");
            return;
        }

        Console.WriteLine("\nContacts:");
        foreach (var c in contacts)
        {
            Console.WriteLine("-------------------------");
            Console.WriteLine(c.ToString());
        }
    }

    public void EditContact()
    {
        Console.Write("Enter First Name of contact to edit: ");
        string firstName = Console.ReadLine() ?? "";
        Console.Write("Enter Last Name of contact to edit: ");
        string lastName = Console.ReadLine() ?? "";

        Contact updated = new Contact();

        Console.WriteLine("Enter new details:");
        Console.Write("Address: ");
        updated.SetAddress(Console.ReadLine());
        Console.Write("City: ");
        updated.SetCity(Console.ReadLine());
        Console.Write("State: ");
        updated.SetState(Console.ReadLine());
        Console.Write("Zip: ");
        updated.SetZip(Console.ReadLine());
        Console.Write("Phone: ");
        updated.SetPhoneNumber(Console.ReadLine());
        Console.Write("Email: ");
        updated.SetEmail(Console.ReadLine());

        bool ok = Repository.UpdateContactByName(AddressBookId, firstName, lastName, updated);
        Console.WriteLine(ok ? "Contact updated." : "Contact not found.");
    }

    public void DeleteContact()
    {
        Console.Write("Enter First Name of contact to delete: ");
        string firstName = Console.ReadLine() ?? "";
        Console.Write("Enter Last Name of contact to delete: ");
        string lastName = Console.ReadLine() ?? "";

        bool ok = Repository.DeleteContactByName(AddressBookId, firstName, lastName);
        Console.WriteLine(ok ? "Contact deleted." : "Contact not found.");
    }

    public void ViewPersonsByCity()
    {
        Console.Write("Enter City Name to view persons: ");
        string city = Console.ReadLine() ?? "";

        List<Contact> contacts = Repository.GetContactsByAddressBook(AddressBookId);
        bool found = false;

        foreach (var c in contacts)
        {
            string contactCity = c.GetCity() ?? "";
            if (string.Equals(contactCity, city, StringComparison.OrdinalIgnoreCase))
            {
                if (!found)
                {
                    Console.WriteLine($"\nPersons in city '{city}' in this Address Book:");
                    found = true;
                }
                Console.WriteLine("-------------------------");
                Console.WriteLine(c.ToString());
            }
        }

        if (!found)
        {
            Console.WriteLine($"No persons found in city '{city}' in this Address Book.");
        }
    }

    public void ViewPersonsByState()
    {
        Console.Write("Enter State Name to view persons: ");
        string state = Console.ReadLine() ?? "";

        List<Contact> contacts = Repository.GetContactsByAddressBook(AddressBookId);
        bool found = false;

        foreach (var c in contacts)
        {
            string contactState = c.GetState() ?? "";
            if (string.Equals(contactState, state, StringComparison.OrdinalIgnoreCase))
            {
                if (!found)
                {
                    Console.WriteLine($"\nPersons in state '{state}' in this Address Book:");
                    found = true;
                }
                Console.WriteLine("-------------------------");
                Console.WriteLine(c.ToString());
            }
        }

        if (!found)
        {
            Console.WriteLine($"No persons found in state '{state}' in this Address Book.");
        }
    }

    public void CountPersonsByCity()
    {
        Console.Write("Enter City Name to get count: ");
        string city = Console.ReadLine() ?? "";

        List<Contact> contacts = Repository.GetContactsByAddressBook(AddressBookId);
        int count = 0;

        foreach (var c in contacts)
        {
            string contactCity = c.GetCity() ?? "";
            if (string.Equals(contactCity, city, StringComparison.OrdinalIgnoreCase))
            {
                count++;
            }
        }

        Console.WriteLine($"Number of persons in city '{city}' in this Address Book: {count}");
    }

    public void CountPersonsByState()
    {
        Console.Write("Enter State Name to get count: ");
        string state = Console.ReadLine() ?? "";

        List<Contact> contacts = Repository.GetContactsByAddressBook(AddressBookId);
        int count = 0;

        foreach (var c in contacts)
        {
            string contactState = c.GetState() ?? "";
            if (string.Equals(contactState, state, StringComparison.OrdinalIgnoreCase))
            {
                count++;
            }
        }

        Console.WriteLine($"Number of persons in state '{state}' in this Address Book: {count}");
    }

    public void SortContactsByName()
    {
        List<Contact> contacts = Repository.GetContactsByAddressBook(AddressBookId);

        if (contacts.Count <= 1)
        {
            Console.WriteLine("Not enough contacts to sort.");
            return;
        }

        contacts.Sort((a, b) =>
        {
            if (a == null && b == null) return 0;
            if (a == null) return 1;
            if (b == null) return -1;

            int first = string.Compare(a.GetFirstName(), b.GetFirstName(), StringComparison.OrdinalIgnoreCase);
            if (first != 0) return first;

            return string.Compare(a.GetLastName(), b.GetLastName(), StringComparison.OrdinalIgnoreCase);
        });

        Console.WriteLine("Contacts sorted alphabetically by name (from DB):");
        foreach (var c in contacts)
        {
            Console.WriteLine("-------------------------");
            Console.WriteLine(c.ToString());
        }
    }
}