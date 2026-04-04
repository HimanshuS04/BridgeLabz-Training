using System;

class Bus
{
    public int DistancePerStop;
    public int TotalDistance;
    public int StopNumber;

    public Bus(int distancePerStop)
    {
        DistancePerStop = distancePerStop;
        TotalDistance = 0;
        StopNumber = 0;
    }

    public void MoveToNextStop()
    {
        StopNumber++;
        TotalDistance += DistancePerStop;

        Console.WriteLine("\nBus reached Stop " + StopNumber);
        Console.WriteLine("Total Distance: " + TotalDistance + " km");
    }
}
