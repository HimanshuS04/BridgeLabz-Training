using System;
public interface IATMService
{
    void InitializeNotes();
    void DispenseAmount(int amount);
    void RemoveFiveHundred();
}