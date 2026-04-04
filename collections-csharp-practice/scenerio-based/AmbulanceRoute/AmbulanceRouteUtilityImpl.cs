using System;
using System.Collections.Generic;

public class AmbulanceRouteUtilityImpl : IAmbulanceRoute
{
    private List<HospitalUnit> units;
    private int currentIndex;

    public AmbulanceRouteUtilityImpl()
    {
        units = new List<HospitalUnit>();
        currentIndex = 0;

        // Predefined circular units
        units.Add(new HospitalUnit("Emergency", true));
        units.Add(new HospitalUnit("Radiology", false));
        units.Add(new HospitalUnit("Surgery", true));
        units.Add(new HospitalUnit("ICU", true));
    }

    // Display all units
    public void DisplayUnits()
    {
        if (units.Count == 0)
        {
            Console.WriteLine("No hospital units available.");
            return;
        }

        foreach (HospitalUnit unit in units)
        {
            Console.WriteLine(unit);
        }
    }

    // Circular rotation to find available unit
    public void FindNextAvailableUnit()
    {
        if (units.Count == 0)
        {
            Console.WriteLine("No units available.");
            return;
        }

        int startIndex = currentIndex;

        do
        {
            HospitalUnit unit = units[currentIndex];

            if (unit.IsAvailable())
            {
                Console.WriteLine("Redirect patient to: " + unit.GetUnitName());

                // Move circularly
                currentIndex = (currentIndex + 1) % units.Count;
                return;
            }

            currentIndex = (currentIndex + 1) % units.Count;

        } while (currentIndex != startIndex);

        Console.WriteLine("No available units at the moment.");
    }

    // Toggle availability
    public void ToggleAvailability()
    {
        Console.Write("Enter unit name: ");
        string name = Console.ReadLine();

        foreach (HospitalUnit unit in units)
        {
            if (unit.GetUnitName().Equals(name))
            {
                unit.SetAvailable(!unit.IsAvailable());
                Console.WriteLine("Availability updated.");
                return;
            }
        }

        Console.WriteLine("Unit not found.");
    }

    // Remove unit for maintenance
    public void RemoveUnit()
    {
        Console.Write("Enter unit name to remove: ");
        string name = Console.ReadLine();

        for (int i = 0; i < units.Count; i++)
        {
            if (units[i].GetUnitName().Equals(name))
            {
                units.RemoveAt(i);

                // Adjust index if needed
                if (currentIndex >= units.Count)
                    currentIndex = 0;

                Console.WriteLine("Unit removed for maintenance.");
                return;
            }
        }

        Console.WriteLine("Unit not found.");
    }
}
