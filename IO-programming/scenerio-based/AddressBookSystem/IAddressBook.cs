public interface IAddressBook
{
    void AddContact();
    void AddMultipleContacts();
    void DisplayContact();
    void EditContact();
    void DeleteContact();

    void ViewPersonsByCity();
    void ViewPersonsByState();

    void CountPersonsByCity();
    void CountPersonsByState();

    void SortContactsByName();
     // NEW: File I/O methods
    void WriteToFile();   // Save this Address Book's contacts to a file
    void ReadFromFile();  // Load contacts from a file into this Address Book
}