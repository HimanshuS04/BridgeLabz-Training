using System;
public interface IAmbulanceRoute
{
    void DisplayUnits();
    void FindNextAvailableUnit();
    void RemoveUnit();
    void ToggleAvailability();
}
