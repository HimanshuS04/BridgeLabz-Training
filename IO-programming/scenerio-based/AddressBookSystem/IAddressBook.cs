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
    void WriteToFile();   
    void ReadFromFile();  
     void WriteToCsvFile();
    void ReadFromCsvFile();
    void WriteToJsonFile();
    void ReadFromJsonFile();
}