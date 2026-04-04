
class Program
{
    static void Main(string[] args)
    {
        IRegistrationService service = new RegistrationService();
        Menu menu = new Menu(service);
        menu.Show();
    }
}

