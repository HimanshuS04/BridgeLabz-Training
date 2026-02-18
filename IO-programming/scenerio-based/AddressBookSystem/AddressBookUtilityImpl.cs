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

    // Save this Address Book's contacts to a file
    public void WriteToFile()
    {
        if (Contacts.Count == 0)
        {
            Console.WriteLine("No contacts in this Address Book to save.");
            return;
        }

        Console.Write("Enter file name to save (e.g., addressbook.txt): ");
        string fileName = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(fileName))
        {
            Console.WriteLine("File name cannot be empty.");
            return;
        }

        try
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (Contact c in Contacts)
                {
                    if (c == null) continue;

                    // Simple '|' separated format: FirstName|LastName|Address|City|State|Zip|Phone|Email
                    string line = string.Join("|", new string[]
                    {
                        c.GetFirstName() ?? "",
                        c.GetLastName() ?? "",
                        c.GetAddress() ?? "",
                        c.GetCity() ?? "",
                        c.GetState() ?? "",
                        c.GetZip() ?? "",
                        c.GetPhoneNumber() ?? "",
                        c.GetEmail() ?? ""
                    });

                    writer.WriteLine(line);
                }
            }

            Console.WriteLine("Contacts saved to file '" + fileName + "'.");
        }
        catch (Exception ex)
        {
            // Wrap any file I/O exception into a domain-specific exception
            throw new AddressBookException("Error writing to file: " + ex.Message, ex);
        }
    }

    // Load contacts from a file into this Address Book
    public void ReadFromFile()
    {
        Console.Write("Enter file name to load (e.g., addressbook.txt): ");
        string fileName = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(fileName))
        {
            Console.WriteLine("File name cannot be empty.");
            return;
        }

        if (!File.Exists(fileName))
        {
            Console.WriteLine("File '" + fileName + "' does not exist.");
            return;
        }

        try
        {
            string[] lines = File.ReadAllLines(fileName);

            // Replace current contacts with file contents
            Contacts.Clear();

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                string[] parts = line.Split('|');
                if (parts.Length != 8)
                {
                    // Skip malformed lines silently
                    continue;
                }

                Contact c = new Contact();
                c.SetFirstName(parts[0]);
                c.SetLastName(parts[1]);
                c.SetAddress(parts[2]);
                c.SetCity(parts[3]);
                c.SetState(parts[4]);
                c.SetZip(parts[5]);
                c.SetPhoneNumber(parts[6]);
                c.SetEmail(parts[7]);

                Contacts.Add(c);
            }

            Console.WriteLine("Contacts loaded from file '" + fileName + "'.");
        }
        catch (Exception ex)
        {
            throw new AddressBookException("Error reading from file: " + ex.Message, ex);
        }
    }
     public void WriteToCsvFile()
    {
        if (Contacts.Count == 0)
        {
            Console.WriteLine("No contacts in this Address Book to save.");
            return;
        }

        Console.Write("Enter CSV file name to save (e.g., addressbook.csv): ");
        string fileName = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(fileName))
        {
            Console.WriteLine("File name cannot be empty.");
            return;
        }

        try
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                // Optional header row
                writer.WriteLine("FirstName,LastName,Address,City,State,Zip,Phone,Email");

                foreach (Contact c in Contacts)
                {
                    if (c == null) continue;

                    string line = string.Join(",", new string[]
                    {
                        c.GetFirstName() ?? "",
                        c.GetLastName() ?? "",
                        c.GetAddress() ?? "",
                        c.GetCity() ?? "",
                        c.GetState() ?? "",
                        c.GetZip() ?? "",
                        c.GetPhoneNumber() ?? "",
                        c.GetEmail() ?? ""
                    });

                    writer.WriteLine(line);
                }
            }

            Console.WriteLine("Contacts saved to CSV file '" + fileName + "'.");
        }
        catch (Exception ex)
        {
            throw new AddressBookException("Error writing CSV file: " + ex.Message, ex);
        }
    }

    public void ReadFromCsvFile()
    {
        Console.Write("Enter CSV file name to load  ");
        string fileName = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(fileName))
        {
            Console.WriteLine("File name cannot be empty.");
            return;
        }

        if (!File.Exists(fileName))
        {
            Console.WriteLine("CSV file '" + fileName + "' does not exist.");
            return;
        }

        try
        {
            string[] lines = File.ReadAllLines(fileName);
            Contacts.Clear();

            bool isFirstLine = true;
            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                // Skip header if present
                if (isFirstLine && line.StartsWith("FirstName", StringComparison.OrdinalIgnoreCase))
                {
                    isFirstLine = false;
                    continue;
                }
                isFirstLine = false;

                string[] parts = line.Split(',');
                if (parts.Length < 8)
                {
                    continue;
                }

                Contact c = new Contact();
                c.SetFirstName(parts[0]);
                c.SetLastName(parts[1]);
                c.SetAddress(parts[2]);
                c.SetCity(parts[3]);
                c.SetState(parts[4]);
                c.SetZip(parts[5]);
                c.SetPhoneNumber(parts[6]);
                c.SetEmail(parts[7]);

                Contacts.Add(c);
            }

            Console.WriteLine("Contacts loaded from CSV file '" + fileName + "'.");
        }
        catch (Exception ex)
        {
            throw new AddressBookException("Error reading CSV file: " + ex.Message, ex);
        }
    }
}