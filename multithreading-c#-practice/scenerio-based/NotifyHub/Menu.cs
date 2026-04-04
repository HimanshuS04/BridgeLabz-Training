public class Menu
{
    private INotification processor;

    public Menu()
    {
        INotificationSender sender = new EmailSender();
        processor = new NotificationUtilityImpl(sender);
    }

    public void Start()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n1. Add Notification");
            Console.WriteLine("2. Process All");
            Console.WriteLine("3. Exit");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddNotification();
                    break;

                case 2:
                    processor.ProcessAll();
                    break;

                case 3:
                    running = false;
                    break;
            }
        }
    }

    private void AddNotification()
    {
        Notification n = new Notification();

        Console.Write("ID: ");
        n.Id = Console.ReadLine();

        Console.Write("Recipient: ");
        n.Recipient = Console.ReadLine();

        Console.Write("Message: ");
        n.Message = Console.ReadLine();

        Console.WriteLine("Priority: 1-Low 2-Medium 3-High");
        int p = int.Parse(Console.ReadLine());

        n.Priority = (PriorityLevel)p;
        n.Type = NotificationType.Email;

        processor.Enqueue(n);

        Console.WriteLine("Notification Added.");
    }
}
