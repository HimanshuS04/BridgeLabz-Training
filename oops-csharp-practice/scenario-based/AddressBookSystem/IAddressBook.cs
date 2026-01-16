using System;
public interface IAddressBook
{
    public void AddContact();
    public void DisplayContact();
    public void EditContact();
    public void DeleteContact();
    public void AddMultipleContacts();
    void SearchPersonByCity();
    void SearchPersonByState();
    void CountPersonsByCity();
    void CountPersonsByState();
}