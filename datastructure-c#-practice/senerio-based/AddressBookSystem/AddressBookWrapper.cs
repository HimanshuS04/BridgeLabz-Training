public class AddressBookWrapper
{
    public string Name;
    public IAddressBook Book;

    public AddressBookWrapper(string name, IAddressBook book)
    {
        Name = name;
        Book = book;
    }
}
