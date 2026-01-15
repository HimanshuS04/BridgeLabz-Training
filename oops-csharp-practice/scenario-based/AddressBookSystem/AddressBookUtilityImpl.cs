using System;

public class AddressBookUtilityImpl : IAddressBook
{
    private Contact[] Contacts = new Contact[100];
    private int ContactCount = 0;
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

        if (ContactCount < Contacts.Length)
        {
            Contacts[ContactCount] = contact;
            ContactCount++;
        }
        else
        {
            Console.WriteLine("Address book is full. Cannot add more contacts.");
        }
    }

    // Method to display the contacts 
    public void DisplayContact()
    {
        if (ContactCount == 0)
        {
            Console.WriteLine("No contacts to display.");
            return;
        }

        for (int i = 0; i < ContactCount; i++)
        {
            if (Contacts[i] != null)
            {
                Console.WriteLine(Contacts[i].ToString());
                Console.WriteLine();
            }
        }
    }

    // Method to edit an existing contact using FIRST + LAST name
    public void EditContact()
    {
        if (ContactCount == 0)
        {
            Console.WriteLine("No contacts available to edit.");
            return;
        }

        Console.Write("Enter the First Name of the contact to edit: ");
        string firstNameToEdit = Console.ReadLine();

        Console.Write("Enter the Last Name of the contact to edit: ");
        string lastNameToEdit = Console.ReadLine();

        Contact contactToEdit = null;

        for (int i = 0; i < ContactCount; i++)
        {
            Contact contact = Contacts[i];
            if (contact == null)
            {
                continue;
            }

            bool firstNameMatches = string.Equals(
                contact.GetFirstName(),
                firstNameToEdit,
                StringComparison.OrdinalIgnoreCase);

            bool lastNameMatches = string.Equals(
                contact.GetLastName(),
                lastNameToEdit,
                StringComparison.OrdinalIgnoreCase);

            if (firstNameMatches && lastNameMatches)
            {
                contactToEdit = contact;
                break;
            }
        }

        if (contactToEdit == null)
        {
            Console.WriteLine("Contact with the given first and last name was not found.");
            return;
        }

        Console.WriteLine("\nExisting contact details:");
        Console.WriteLine(contactToEdit.ToString());

        Console.WriteLine("\nEnter new details:");
        TakeContactInput(contactToEdit);

        Console.WriteLine("\nContact updated successfully. New details:");
        // Console.WriteLine(contactToEdit.ToString());
    }
    // Method to delete an existing contact using FIRST + LAST name
    public void DeleteContact()
    {
        if (ContactCount == 0)
        {
            Console.WriteLine("No contacts available to delete.");
            return;
        }

        Console.Write("Enter the First Name of the contact to delete: ");
        string firstNameToDelete = Console.ReadLine();

        Console.Write("Enter the Last Name of the contact to delete: ");
        string lastNameToDelete = Console.ReadLine();

        int indexToDelete = -1;

        for (int i = 0; i < ContactCount; i++)
        {
            Contact c = Contacts[i];
            if (c == null)
            {
                continue;
            }

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
            Console.WriteLine("Contact with the given first and last name was not found.");
            return;
        }

        // Shift elements left to fill the gap
        for (int i = indexToDelete; i < ContactCount - 1; i++)
        {
            Contacts[i] = Contacts[i + 1];
        }

        Contacts[ContactCount - 1] = null;
        ContactCount--;

        Console.WriteLine("Contact deleted successfully.");
    }
}