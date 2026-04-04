using System;
public class Menu
    {
        private IRegistrationService service;

        public Menu(IRegistrationService service)
        {
            this.service = service;
        }

        public void Show()
        {
            while (true)
            {
                Console.WriteLine("\n==== EduConnect Portal ====");
                Console.WriteLine("1. Register Email");
                Console.WriteLine("2. Exit");
                Console.Write("Choose option: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Email: ");
                        string email = Console.ReadLine();
                        service.RegisterEmail(email);
                        break;

                    case 2:
                        return;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
        }
    }

