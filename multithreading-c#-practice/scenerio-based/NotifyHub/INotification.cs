public interface INotification
{
    void Enqueue(Notification notification);
    void ProcessAll();
}
