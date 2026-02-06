using System;
using System.Collections.Generic;

public class AddressBookUtilityImpl : IAddressBook
{
    private List<Contact> Contacts = new List<Contact>();

    // Common method to take input for a contact (used by Add and Edit)
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

    // Duplicate check: same FirstName + LastName in this Address Book
    private bool IsDuplicateContact(Contact newContact)
    {
        string newFirstName = newContact.GetFirstName() ?? string.Empty;
        string newLastName = newContact.GetLastName() ?? string.Empty;

        foreach (Contact existing in Contacts)
        {
            if (existing == null)
            {
                continue;
            }

            bool firstNameMatches = string.Equals(
                existing.GetFirstName(),
                newFirstName,
                StringComparison.OrdinalIgnoreCase);

            bool lastNameMatches = string.Equals(
                existing.GetLastName(),
                newLastName,
                StringComparison.OrdinalIgnoreCase);

            if (firstNameMatches && lastNameMatches)
            {
                return true;
            }
        }

        return false;
    }

    public void AddContact()
    {
        Contact contact = new Contact();
        TakeContactInput(contact);

        if (IsDuplicateContact(contact))
        {
            throw new DuplicateContactException(contact.GetFirstName(), contact.GetLastName());
        }

        Contacts.Add(contact);
    }

    public void AddMultipleContacts()
    {
        Console.Write("How many contacts do you want to add? ");
        string input = Console.ReadLine();
        int numberOfContacts;

        try
        {
            numberOfContacts = int.Parse(input);
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter a valid integer.");
            return;
        }
        catch (OverflowException)
        {
            Console.WriteLine("Number is too large.");
            return;
        }

        if (numberOfContacts <= 0)
        {
            Console.WriteLine("Number must be greater than zero.");
            return;
        }

        for (int i = 0; i < numberOfContacts; i++)
        {
            Console.WriteLine($"\nEntering details for contact {i + 1}:");
            try
            {
                AddContact();
            }
            catch (DuplicateContactException ex)
            {
                Console.WriteLine("DuplicateContactFoundException " + ex.Message);
            }
        }
    }

    public void DisplayContact()
    {
        if (Contacts.Count == 0)
        {
            Console.WriteLine("No contacts to display.");
            return;
        }

        foreach (Contact c in Contacts)
        {
            if (c != null)
            {
                Console.WriteLine(c.ToString());
                Console.WriteLine();
            }
        }
    }

    public void EditContact()
    {
        if (Contacts.Count == 0)
        {
            throw new AddressBookException("No contacts available to edit.");
        }

        Console.Write("Enter the First Name of the contact to edit: ");
        string firstNameToEdit = Console.ReadLine() ;

        Console.Write("Enter the Last Name of the contact to edit: ");
        string lastNameToEdit = Console.ReadLine() ;

        Contact contactToEdit = null;

        foreach (Contact c in Contacts)
        {
            if (c == null) continue;

            bool firstNameMatches = string.Equals(
                c.GetFirstName(),
                firstNameToEdit,
                StringComparison.OrdinalIgnoreCase);

            bool lastNameMatches = string.Equals(
                c.GetLastName(),
                lastNameToEdit,
                StringComparison.OrdinalIgnoreCase);

            if (firstNameMatches && lastNameMatches)
            {
                contactToEdit = c;
                break;
            }
        }

        if (contactToEdit == null)
        {
            throw new ContactNotFoundException(firstNameToEdit, lastNameToEdit);
        }

        Console.WriteLine("\nExisting contact details:");
        Console.WriteLine(contactToEdit.ToString());

        Console.WriteLine("\nEnter new details:");
        TakeContactInput(contactToEdit);

        Console.WriteLine("\nContact updated successfully. New details:");
        Console.WriteLine(contactToEdit.ToString());
    }

    public void DeleteContact()
    {
        if (Contacts.Count == 0)
        {
            throw new AddressBookException("No contacts available to delete.");
        }

        Console.Write("Enter the First Name of the contact to delete: ");
        string firstNameToDelete = Console.ReadLine() ;

        Console.Write("Enter the Last Name of the contact to delete: ");
        string lastNameToDelete = Console.ReadLine() ;

        int indexToDelete = -1;

        for (int i = 0; i < Contacts.Count; i++)
        {
            Contact c = Contacts[i];
            if (c == null) continue;

            bool firstNameMatches = string.Equals(
                c.GetFirstName(),
                firstNameToDelete,
                StringComparison.OrdinalIgnoreCase);

            bool lastNameMatches = string.Equals(
                c.GetLastName(),
                lastNameToDelete,
                StringComparison.OrdinalIgnoreCase);

            if (firstNameMatches && lastNameMatches)
            {
                indexToDelete = i;
                break;
            }
        }

        if (indexToDelete == -1)
        {
            throw new ContactNotFoundException(firstNameToDelete, lastNameToDelete);
        }

        Contacts.RemoveAt(indexToDelete);
        Console.WriteLine("Contact deleted successfully.");
    }

    public void ViewPersonsByCity()
    {
        if (Contacts.Count == 0)
        {
            Console.WriteLine("No contacts in this Address Book.");
            return;
        }

        Console.Write("Enter City Name to view persons: ");
        string city = Console.ReadLine() ?? string.Empty;

        bool found = false;

        foreach (Contact c in Contacts)
        {
            if (c == null) continue;

            if (string.Equals(c.GetCity(), city, StringComparison.OrdinalIgnoreCase))
            {
                if (!found)
                {
                    Console.WriteLine("\nPersons in city '" + city + "' (this Address Book):");
                    found = true;
                }
                Console.WriteLine(c.ToString());
                Console.WriteLine();
            }
        }

        if (!found)
        {
            Console.WriteLine("No persons found in city '" + city + "' in this Address Book.");
        }
    }

    public void ViewPersonsByState()
    {
        if (Contacts.Count == 0)
        {
            Console.WriteLine("No contacts in this Address Book.");
            return;
        }

        Console.Write("Enter State Name to view persons: ");
        string state = Console.ReadLine() ;

        bool found = false;

        foreach (Contact c in Contacts)
        {
            if (c == null) continue;

            if (string.Equals(c.GetState(), state, StringComparison.OrdinalIgnoreCase))
            {
                if (!found)
                {
                    Console.WriteLine("\nPersons in state '" + state + "' (this Address Book):");
                    found = true;
                }
                Console.WriteLine(c.ToString());
                Console.WriteLine();
            }
        }

        if (!found)
        {
            Console.WriteLine("No persons found in state '" + state + "' in this Address Book.");
        }
    }

    public void CountPersonsByCity()
    {
        if (Contacts.Count == 0)
        {
            Console.WriteLine("No contacts in this Address Book.");
            return;
        }

        Console.Write("Enter City Name to get count: ");
        string city = Console.ReadLine() ;

        int count = 0;

        foreach (Contact c in Contacts)
        {
            if (c == null) continue;

            if (string.Equals(c.GetCity(), city, StringComparison.OrdinalIgnoreCase))
            {
                count++;
            }
        }

        Console.WriteLine("Number of persons in city '" + city + "' in this Address Book: " + count);
    }

    public void CountPersonsByState()
    {
        if (Contacts.Count == 0)
        {
            Console.WriteLine("No contacts in this Address Book.");
            return;
        }

        Console.Write("Enter State Name to get count: ");
        string state = Console.ReadLine() ?? string.Empty;

        int count = 0;

        foreach (Contact c in Contacts)
        {
            if (c == null) continue;

            if (string.Equals(c.GetState(), state, StringComparison.OrdinalIgnoreCase))
            {
                count++;
            }
        }

        Console.WriteLine("Number of persons in state '" + state + "' in this Address Book: " + count);
    }

    private int CompareContactsByName(Contact a, Contact b)
    {
        if (a == null && b == null) return 0;
        if (a == null) return 1;
        if (b == null) return -1;

        int firstNameCompare = string.Compare(
            a.GetFirstName(),
            b.GetFirstName(),
            StringComparison.OrdinalIgnoreCase);

        if (firstNameCompare != 0)
        {
            return firstNameCompare;
        }

        return string.Compare(
            a.GetLastName(),
            b.GetLastName(),
            StringComparison.OrdinalIgnoreCase);
    }

    public void SortContactsByName()
    {
        if (Contacts.Count <= 1)
        {
            Console.WriteLine("Not enough contacts to sort.");
            return;
        }

        Contacts.Sort(CompareContactsByName);

        Console.WriteLine("Contacts sorted alphabetically by name in this Address Book.");
        Console.WriteLine("Sorted list:");
        DisplayContact();
    }
}