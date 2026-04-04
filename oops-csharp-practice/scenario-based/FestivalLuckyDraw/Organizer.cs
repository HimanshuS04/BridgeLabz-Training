using System;
class Organizer
{
    public int visitorCount;
    public string[] visitorNames;

    public void AddVisitors()
    {
        Console.Write("Enter number of visitors: ");
        visitorCount = Convert.ToInt32(Console.ReadLine());

        visitorNames = new string[visitorCount];

        for (int i = 0; i < visitorCount; i++)
        {
            Console.Write("Enter name of visitor " + (i + 1) + ": ");
            visitorNames[i] = Console.ReadLine();
        }
    }
}
