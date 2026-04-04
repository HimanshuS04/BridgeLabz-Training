using System;
class TimeZoneDemo
{
    public static void Main(string[] args)
    {
        DateTimeOffset utcNow = DateTimeOffset.UtcNow;

        Console.WriteLine("GMT time : " + utcNow);

        TimeZoneInfo istZone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        DateTimeOffset istTime = TimeZoneInfo.ConvertTime(utcNow, istZone);
        Console.WriteLine("IST time : " + istTime);

        TimeZoneInfo pstZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
        DateTimeOffset pstTime = TimeZoneInfo.ConvertTime(utcNow, pstZone);
        Console.WriteLine("PST Time : " + pstTime);
    }
}