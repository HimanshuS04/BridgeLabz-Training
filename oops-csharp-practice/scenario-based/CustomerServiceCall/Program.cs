using System;

class Program
{
    static void Main()
    {
        CallLogManager manager = new CallLogManager(5);

        manager.AddCallLog(new CallLog("9876543210", "Network issue reported", DateTime.Now.AddMinutes(-90)));
        manager.AddCallLog(new CallLog("9123456780", "Billing related query", DateTime.Now.AddMinutes(-60)));
        manager.AddCallLog(new CallLog("9988776655", "Internet speed is slow", DateTime.Now.AddMinutes(-30)));
        manager.AddCallLog(new CallLog("9090909090", "Network issue resolved", DateTime.Now));

        manager.SearchByKeyword("network");

        DateTime startTime = DateTime.Now.AddHours(-2);
        DateTime endTime = DateTime.Now;

        manager.FilterByTime(startTime, endTime);
    }
}
