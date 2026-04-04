using System;

public class Contact
{
    private string FirstName;
    private string LastName;
    private string Address;
    private string City;
    private string State;
    private string Zip;
    private string PhoneNumber;
    private string Email;

    public string GetFirstName()
    {
        return FirstName;
    }

    public void SetFirstName(string value)
    {
        FirstName = value;
    }

    public string GetLastName()
    {
        return LastName;
    }

    public void SetLastName(string value)
    {
        LastName = value;
    }

    public string GetAddress()
    {
        return Address;
    }

    public void SetAddress(string value)
    {
        Address = value;
    }

    public string GetCity()
    {
        return City;
    }

    public void SetCity(string value)
    {
        City = value;
    }

    public string GetState()
    {
        return State;
    }

    public void SetState(string value)
    {
        State = value;
    }

    public string GetZip()
    {
        return Zip;
    }

    public void SetZip(string value)
    {
        Zip = value;
    }

    public string GetPhoneNumber()
    {
        return PhoneNumber;
    }

    public void SetPhoneNumber(string value)
    {
        PhoneNumber = value;
    }

    public string GetEmail()
    {
        return Email;
    }

    public void SetEmail(string value)
    {
        Email = value;
    }

    public override string ToString()
    {
        return "First Name: " + FirstName + "\n"
             + "Last Name: " + LastName + "\n"
             + "Address: " + Address + "\n"
             + "City: " + City + "\n"
             + "State: " + State + "\n"
             + "Zip: " + Zip + "\n"
             + "Phone Number: " + PhoneNumber + "\n"
             + "Email: " + Email;
    }
}