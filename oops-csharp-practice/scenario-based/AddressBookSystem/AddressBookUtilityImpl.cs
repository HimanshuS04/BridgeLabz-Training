public class AddressBookUtilityImpl:IAddressBook
{
    private Contact[] Contacts= new Contact[100];
    private int ContactCount=0;
     public void AddContact()
    {
        Contact contact = new Contact();

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
    public void DisplayContact()
    {
        for(int i = 0; i < ContactCount; i++)
        {
           Console.WriteLine(Contacts[i].ToString());
           Console.WriteLine();
        }
    }
}

