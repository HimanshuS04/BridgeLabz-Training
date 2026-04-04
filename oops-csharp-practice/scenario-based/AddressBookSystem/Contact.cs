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

    // FirstName
    public string GetFirstName()
    {
        return FirstName;
    }

    public void SetFirstName(string value)
    {
        FirstName = value;
    }

    // LastName
    public string GetLastName()
    {
        return LastName;
    }

    public void SetLastName(string value)
    {
        LastName = value;
    }

    // Address
    public string GetAddress()
    {
        return Address;
    }

    public void SetAddress(string value)
    {
        Address = value;
    }

    // City
    public string GetCity()
    {
        return City;
    }

    public void SetCity(string value)
    {
        City = value;
    }

    // State
    public string GetState()
    {
        return State;
    }

    public void SetState(string value)
    {
        State = value;
    }

    // Zip
    public string GetZip()
    {
        return Zip;
    }

    public void SetZip(string value)
    {
        Zip = value;
    }

    // PhoneNumber
    public string GetPhoneNumber()
    {
        return PhoneNumber;
    }

    public void SetPhoneNumber(string value)
    {
        PhoneNumber = value;
    }

    // Email
    public string GetEmail()
    {
        return Email;
    }

    public void SetEmail(string value)
    {
        Email = value;
    }
    // ToString
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