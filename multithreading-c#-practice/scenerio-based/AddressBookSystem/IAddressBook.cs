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
    Task WriteToFileAsync();
    Task ReadFromFileAsync();

    Task WriteToCsvFileAsync();
    Task ReadFromCsvFileAsync();

    Task WriteToJsonFileAsync();
    Task ReadFromJsonFileAsync();
}