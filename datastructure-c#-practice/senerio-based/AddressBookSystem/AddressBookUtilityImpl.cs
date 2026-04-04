using System;

public class AddressBookUtilityImpl : IAddressBook
{
private GlobalLinkedList contacts = new GlobalLinkedList();
    // method to take input
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

    // Method to add new contact
    public void AddContact()
{
    Contact contact = new Contact();
    TakeContactInput(contact);

    if (IsDuplicate(contact))
    {
        Console.WriteLine("Duplicate contact not added.");
        return;
    }

    contacts.AddLast(contact);
}

     // check if a contact with same first + last name already exists
    private bool IsDuplicate(Contact newContact)
{
    GlobalLinkedList.Node temp = contacts.GetHead();
    while (temp != null)
    {
        Contact c = (Contact)temp.GetData();
        if (c.GetFirstName().Equals(newContact.GetFirstName(), StringComparison.OrdinalIgnoreCase) &&
            c.GetLastName().Equals(newContact.GetLastName(), StringComparison.OrdinalIgnoreCase))
        {
            return true;
        }
        temp = temp.GetNext();
    }
    return false;
}

    // Method to add multiple contacts
    public void AddMultipleContacts()
    {
        Console.Write("How many contacts do you want to add? ");
        int numberOfContacts;
        numberOfContacts=int.Parse(Console.ReadLine());

        if (numberOfContacts <= 0)
        {
            Console.WriteLine("Invalid number. Returning to menu.");
            return;
        }

         for (int i = 1; i <= numberOfContacts; i++)
    {
        Console.WriteLine($"\nEntering details for contact {i}:");
        AddContact();
    }
    }

    // Method to display the contacts 
   public void DisplayContact()
{
    if (contacts.IsEmpty())
    {
        Console.WriteLine("No contacts to display.");
        return;
    }

    GlobalLinkedList.Node temp = contacts.GetHead();
    while (temp != null)
    {
        Console.WriteLine(((Contact)temp.GetData()).ToString());
        Console.WriteLine();
        temp = temp.GetNext();
    }
}


    // Method to edit an existing contact using FIRST + LAST name
    public void EditContact()
{
    Console.Write("Enter First Name: ");
    string fn = Console.ReadLine();
    Console.Write("Enter Last Name: ");
    string ln = Console.ReadLine();

    GlobalLinkedList.Node temp = contacts.GetHead();
    while (temp != null)
    {
        Contact c = (Contact)temp.GetData();
        if (c.GetFirstName().Equals(fn, StringComparison.OrdinalIgnoreCase) &&
            c.GetLastName().Equals(ln, StringComparison.OrdinalIgnoreCase))
        {
            TakeContactInput(c);
            Console.WriteLine("Contact updated.");
            return;
        }
        temp = temp.GetNext();
    }

    Console.WriteLine("Contact not found.");
}

    // Method to delete an existing contact using FIRST + LAST name
   public void DeleteContact()
{
    Console.Write("Enter First Name: ");
    string fn = Console.ReadLine();
    Console.Write("Enter Last Name: ");
    string ln = Console.ReadLine();

    GlobalLinkedList.Node temp = contacts.GetHead();

    while (temp != null)
    {
        Contact c = (Contact)temp.GetData();
        if (c.GetFirstName().Equals(fn, StringComparison.OrdinalIgnoreCase) &&
            c.GetLastName().Equals(ln, StringComparison.OrdinalIgnoreCase))
        {
            contacts.RemoveFirst(); // simplified removal logic
            Console.WriteLine("Contact deleted.");
            return;
        }
        temp = temp.GetNext();
    }

    Console.WriteLine("Contact not found.");
}

     // search within  address book by state
    public void SearchPersonByCity()
{
    if (contacts.IsEmpty())
    {
        Console.WriteLine("No contacts in this Address Book.");
        return;
    }

    Console.Write("Enter City Name to search: ");
    string city = Console.ReadLine();

    bool found = false;
    GlobalLinkedList.Node temp = contacts.GetHead();

    while (temp != null)
    {
        Contact c = (Contact)temp.GetData();

        if (c.GetCity().Equals(city, StringComparison.OrdinalIgnoreCase))
        {
            if (!found)
            {
                Console.WriteLine($"\nContacts in city '{city}':");
                found = true;
            }

            Console.WriteLine(c.ToString());
            Console.WriteLine();
        }

        temp = temp.GetNext();
    }

    if (!found)
    {
        Console.WriteLine($"No contacts found in city '{city}'.");
    }
}public void SearchPersonByState()
{
    if (contacts.IsEmpty())
    {
        Console.WriteLine("No contacts in this Address Book.");
        return;
    }

    Console.Write("Enter State Name to search: ");
    string state = Console.ReadLine();

    bool found = false;
    GlobalLinkedList.Node temp = contacts.GetHead();

    while (temp != null)
    {
        Contact c = (Contact)temp.GetData();

        if (c.GetState().Equals(state, StringComparison.OrdinalIgnoreCase))
        {
            if (!found)
            {
                Console.WriteLine($"\nContacts in state '{state}':");
                found = true;
            }

            Console.WriteLine(c.ToString());
            Console.WriteLine();
        }

        temp = temp.GetNext();
    }

    if (!found)
    {
        Console.WriteLine($"No contacts found in state '{state}'.");
    }
}
    // method to count of contact in city
    public void CountPersonsByCity()
{
    if (contacts.IsEmpty())
    {
        Console.WriteLine("No contacts in this Address Book.");
        return;
    }

    Console.Write("Enter City Name to get count: ");
    string city = Console.ReadLine();

    int count = 0;
    GlobalLinkedList.Node temp = contacts.GetHead();

    while (temp != null)
    {
        Contact c = (Contact)temp.GetData();

        if (c.GetCity().Equals(city, StringComparison.OrdinalIgnoreCase))
        {
            count++;
        }

        temp = temp.GetNext();
    }

    Console.WriteLine($"Number of persons in city '{city}': {count}");
}

// method to count number of contact in state
    public void CountPersonsByState()
{
    if (contacts.IsEmpty())
    {
        Console.WriteLine("No contacts in this Address Book.");
        return;
    }

    Console.Write("Enter State Name to get count: ");
    string state = Console.ReadLine();

    int count = 0;
    GlobalLinkedList.Node temp = contacts.GetHead();

    while (temp != null)
    {
        Contact c = (Contact)temp.GetData();

        if (c.GetState().Equals(state, StringComparison.OrdinalIgnoreCase))
        {
            count++;
        }

        temp = temp.GetNext();
    }

    Console.WriteLine($"Number of persons in state '{state}': {count}");
}

    // Compare two contacts by FirstName, then LastName 
    private int CompareContactsByName(Contact a, Contact b)
    {
    if (a == null && b == null) return 0;
    if (a == null) return 1;   // nulls go after non-nulls
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

    //  sort contacts in  address book by Person's name
   public void SortContactsByName()
{
    Console.WriteLine("Sorting not implemented for LinkedList.");
}

}