using System;

public class AddressBookMain
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to address book system");

        AddressBookMenu menu = new AddressBookMenu();
        menu.ShowMenu();
    }
}