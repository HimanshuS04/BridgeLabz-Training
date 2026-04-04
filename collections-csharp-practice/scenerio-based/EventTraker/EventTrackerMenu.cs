using System;

public class EventTrackerMenu
{
    private IEventTracker tracker = new EventTrackerUtilityImpl();

    public void ShowMenu()
    {
        while (true)
        {
            Console.WriteLine("\n1. Scan Audit Events");
            Console.WriteLine("2. Generate Audit JSON");
            Console.WriteLine("3. Exit");
            Console.Write("Enter choice: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    tracker.ScanAuditEvents();
                    break;

                case 2:
                    string json = tracker.GenerateAuditJson();
                    Console.WriteLine("\n📄 Audit Log (JSON)");
                    Console.WriteLine(json);
                    break;

                case 3:
                    return;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}
