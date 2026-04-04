using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
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
    public async Task WriteToFileAsync()
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
        var lines = new List<string>();
        foreach (Contact c in Contacts)
        {
            if (c == null) continue;

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

            lines.Add(line);
        }

        await File.WriteAllLinesAsync(fileName, lines);
        Console.WriteLine("Contacts saved to file '" + fileName + "'.");
    }
    catch (Exception ex)
    {
        throw new AddressBookException("Error writing to file: " + ex.Message, ex);
    }
}

    // Load contacts from a file into this Address Book
    public async Task ReadFromFileAsync()
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
        string[] lines = await File.ReadAllLinesAsync(fileName);
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
    public async Task WriteToCsvFileAsync()
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
        var lines = new List<string>
        {
            "FirstName,LastName,Address,City,State,Zip,Phone,Email"
        };

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

            lines.Add(line);
        }

        await File.WriteAllLinesAsync(fileName, lines);
        Console.WriteLine("Contacts saved to CSV file '" + fileName + "'.");
    }
    catch (Exception ex)
    {
        throw new AddressBookException("Error writing CSV file: " + ex.Message, ex);
    }
}
    public async Task ReadFromCsvFileAsync()
{
    Console.Write("Enter CSV file name to load (e.g., addressbook.csv): ");
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
        string[] lines = await File.ReadAllLinesAsync(fileName);
        Contacts.Clear();

        bool isFirstLine = true;
        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

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
   public async Task WriteToJsonFileAsync()
{
    if (Contacts.Count == 0)
    {
        Console.WriteLine("No contacts in this Address Book to save.");
        return;
    }

    Console.Write("Enter JSON file name to save (e.g., addressbook.json): ");
    string fileName = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(fileName))
    {
        Console.WriteLine("File name cannot be empty.");
        return;
    }

    try
    {
        var dtoList = new List<ContactDto>();
        foreach (Contact c in Contacts)
        {
            if (c == null) continue;

            dtoList.Add(new ContactDto
            {
                FirstName = c.GetFirstName(),
                LastName  = c.GetLastName(),
                Address   = c.GetAddress(),
                City      = c.GetCity(),
                State     = c.GetState(),
                Zip       = c.GetZip(),
                Phone     = c.GetPhoneNumber(),
                Email     = c.GetEmail()
            });
        }

        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        string json = JsonSerializer.Serialize(dtoList, options);
        await File.WriteAllTextAsync(fileName, json);

        Console.WriteLine("Contacts saved to JSON file '" + fileName + "'.");
    }
    catch (Exception ex)
    {
        throw new AddressBookException("Error writing JSON file: " + ex.Message, ex);
    }
}
public async Task ReadFromJsonFileAsync()
{
    Console.Write("Enter JSON file name to load (e.g., addressbook.json): ");
    string fileName = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(fileName))
    {
        Console.WriteLine("File name cannot be empty.");
        return;
    }

    if (!File.Exists(fileName))
    {
        Console.WriteLine("JSON file '" + fileName + "' does not exist.");
        return;
    }

    try
    {
        string json = await File.ReadAllTextAsync(fileName);

        List<ContactDto> dtoList =
            JsonSerializer.Deserialize<List<ContactDto>>(json);

        Contacts.Clear();

        if (dtoList != null)
        {
            foreach (ContactDto dto in dtoList)
            {
                Contact c = new Contact();
                c.SetFirstName(dto.FirstName);
                c.SetLastName(dto.LastName);
                c.SetAddress(dto.Address);
                c.SetCity(dto.City);
                c.SetState(dto.State);
                c.SetZip(dto.Zip);
                c.SetPhoneNumber(dto.Phone);
                c.SetEmail(dto.Email);

                Contacts.Add(c);
            }
        }

        Console.WriteLine("Contacts loaded from JSON file '" + fileName + "'.");
    }
    catch (Exception ex)
    {
        throw new AddressBookException("Error reading JSON file: " + ex.Message, ex);
    }
}
}