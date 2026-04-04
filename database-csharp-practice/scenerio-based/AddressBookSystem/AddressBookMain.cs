using System;

public class AddressBookMain
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Address Book System ");

        AddressBookMenu menu = new AddressBookMenu();
        menu.ShowMenu();
    }
}