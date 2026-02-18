using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

public class AddressBookUtilityImpl : IAddressBook
{
    private readonly int AddressBookId;
    private readonly AddressBookRepository Repository;

    // In‑memory list used by view/count/sort and file IO
    private List<Contact> Contacts = new List<Contact>();

    public AddressBookUtilityImpl(int addressBookId, AddressBookRepository repository)
    {
        AddressBookId = addressBookId;
        Repository = repository;
    }

    // Helper: load current contacts for this AddressBook from DB into Contacts list
    private void LoadContactsFromDatabase()
    {
        Contacts = Repository.GetContactsByAddressBook(AddressBookId);
    }

    // Input helper (unchanged from your previous version)
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

    // ========== BASIC CRUD (DB) ==========

    public void AddContact()
    {
        Contact contact = new Contact();
        TakeContactInput(contact);

        Repository.AddContact(AddressBookId, contact);
        LoadContactsFromDatabase(); // keep in‑memory list in sync
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
            AddContact();  // uses DB + refresh
        }
    }

    public void DisplayContact()
    {
        // DB is the source of truth, so load latest contacts first
        LoadContactsFromDatabase();

        if (Contacts.Count == 0)
        {
            Console.WriteLine("No contacts to display.");
            return;
        }

        foreach (var c in Contacts)
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

        LoadContactsFromDatabase();
    }

    public void DeleteContact()
    {
        Console.Write("Enter First Name of contact to delete: ");
        string firstName = Console.ReadLine() ?? "";
        Console.Write("Enter Last Name of contact to delete: ");
        string lastName = Console.ReadLine() ?? "";

        bool ok = Repository.DeleteContactByName(AddressBookId, firstName, lastName);
        Console.WriteLine(ok ? "Contact deleted." : "Contact not found.");

        LoadContactsFromDatabase();
    }

    // ========== VIEW BY CITY / STATE (old logic, but backed by DB data) ==========

    public void ViewPersonsByCity()
    {
        LoadContactsFromDatabase();

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
        LoadContactsFromDatabase();

        if (Contacts.Count == 0)
        {
            Console.WriteLine("No contacts in this Address Book.");
            return;
        }

        Console.Write("Enter State Name to view persons: ");
        string state = Console.ReadLine() ?? string.Empty;

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

    // ========== COUNT BY CITY / STATE (old logic, DB‑backed data) ==========

    public void CountPersonsByCity()
    {
        LoadContactsFromDatabase();

        if (Contacts.Count == 0)
        {
            Console.WriteLine("No contacts in this Address Book.");
            return;
        }

        Console.Write("Enter City Name to get count: ");
        string city = Console.ReadLine() ?? string.Empty;

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
        LoadContactsFromDatabase();

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

    // ========== SORT BY NAME (old logic, DB‑backed data) ==========

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
        LoadContactsFromDatabase();

        if (Contacts.Count <= 1)
        {
            Console.WriteLine("Not enough contacts to sort.");
            return;
        }

        Contacts.Sort(CompareContactsByName);

        Console.WriteLine("Contacts sorted alphabetically by name in this Address Book.");
        Console.WriteLine("Sorted list:");
        foreach (var c in Contacts)
        {
            Console.WriteLine("-------------------------");
            Console.WriteLine(c.ToString());
        }
    }

    // ========== FILE I/O ASYNC (old logic, using Contacts list) ==========

    public async Task WriteToFileAsync()
    {
        LoadContactsFromDatabase();

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
            // NOTE: we are NOT writing these back to DB automatically.
        }
        catch (Exception ex)
        {
            throw new AddressBookException("Error reading from file: " + ex.Message, ex);
        }
    }

    public async Task WriteToCsvFileAsync()
    {
        LoadContactsFromDatabase();

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
        LoadContactsFromDatabase();

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