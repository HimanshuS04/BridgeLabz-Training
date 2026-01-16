using System;
public interface ITrafficManager
{
    void AddVehicleToQueue();
    void AllowVehicleIntoRoundabout();
    void ExitVehicleFromRoundabout();
    void PrintRoundabout();
}