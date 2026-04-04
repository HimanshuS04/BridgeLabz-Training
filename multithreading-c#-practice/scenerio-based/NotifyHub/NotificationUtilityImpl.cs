using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class NotificationUtilityImpl : INotification
{
    private readonly INotificationSender _sender;
    private readonly List<Notification> _notifications =
        new List<Notification>();

    public NotificationUtilityImpl(INotificationSender sender)
    {
        _sender = sender;
    }

    public void Enqueue(Notification notification)
    {
        _notifications.Add(notification);
    }

    public void ProcessAll()
    {
        if (_notifications.Count == 0)
        {
            Console.WriteLine("No notifications to process.");
            return;
        }

        Console.WriteLine("\nProcessing notifications...\n");

        // SORT BY PRIORITY (High first)
        var sortedList = _notifications
            .OrderByDescending(n => n.Priority)
            .ToList();

        Parallel.ForEach(sortedList, notification =>
        {
            _sender.SendAsync(notification).Wait();
            notification.Status = "Sent";

            Console.WriteLine(
                $"Sent to {notification.Recipient} | Priority: {notification.Priority}"
            );
        });

        _notifications.Clear();

        Console.WriteLine("\nAll notifications processed.\n");
    }
}
