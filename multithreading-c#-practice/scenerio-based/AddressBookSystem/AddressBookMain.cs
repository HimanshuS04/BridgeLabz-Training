using System;
using System.Threading.Tasks;
public class AddressBookMain
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine("Welcome to address book system");
            AddressBookMenu menu = new AddressBookMenu();
            await menu.ShowMenuAsync();
    }
}