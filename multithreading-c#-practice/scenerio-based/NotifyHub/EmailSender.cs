using System;
using System.Threading.Tasks;

public class EmailSender : INotificationSender
{
    public async Task SendAsync(Notification notification)
    {
        await Task.Delay(1000);
        Console.WriteLine($"Email sent to {notification.Recipient}");
    }
}
