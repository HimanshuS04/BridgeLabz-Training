using System;

// Base custom exception for the Address Book domain
public class AddressBookException : Exception
{
    public AddressBookException() { }

    public AddressBookException(string message) : base(message) { }

    public AddressBookException(string message, Exception innerException)
        : base(message, innerException) { }
}

// Thrown when a contact with same First + Last name already exists
public class DuplicateContactException : AddressBookException
{
    public DuplicateContactException(string firstName, string lastName)
        : base($"A contact with the name '{firstName} {lastName}' already exists in this Address Book.")
    {
    }
}

// Thrown when a specific contact cannot be found
public class ContactNotFoundException : AddressBookException
{
    public ContactNotFoundException(string firstName, string lastName)
        : base($"Contact '{firstName} {lastName}' was not found in this Address Book.")
    {
    }
}

// Thrown when user tries to create an address book with invalid name
public class InvalidAddressBookNameException : AddressBookException
{
    public InvalidAddressBookNameException()
        : base("Address Book name cannot be null, empty, or whitespace.")
    {
    }
}

// Thrown when an address book with the same name already exists
public class DuplicateAddressBookException : AddressBookException
{
    public DuplicateAddressBookException(string name)
        : base($"An Address Book with the name '{name}' already exists.")
    {
    }
}

// Thrown when user tries to select an address book that doesn't exist
public class AddressBookNotFoundException : AddressBookException
{
    public AddressBookNotFoundException(string name)
        : base($"Address Book '{name}' was not found.")
    {
    }
}