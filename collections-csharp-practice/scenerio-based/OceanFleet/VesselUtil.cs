using System.Collections.Generic;

public class VesselUtil
{
    private List<Vessel> vesselList = new List<Vessel>();

    public List<Vessel> VesselList
    {
        get { return vesselList; }
        set { vesselList = value; }
    }

    // Requirement 1: Add vessel performance
    public void AddVesselPerformance(Vessel vessel)
    {
        vesselList.Add(vessel);
    }

    // Requirement 2: Retrieve vessel by Id
    public Vessel GetVesselById(string vesselId)
    {
        foreach (Vessel vessel in vesselList)
        {
            if (vessel.VesselId.Equals(vesselId))
            {
                return vessel;
            }
        }
        return null;
    }

    // Requirement 3: Get high performance vessels
    public List<Vessel> GetHighPerformanceVessels()
    {
        List<Vessel> result = new List<Vessel>();

        double maxSpeed = 0;

        foreach (Vessel vessel in vesselList)
        {
            if (vessel.AverageSpeed > maxSpeed)
            {
                maxSpeed = vessel.AverageSpeed;
            }
        }

        foreach (Vessel vessel in vesselList)
        {
            if (vessel.AverageSpeed == maxSpeed)
            {
                result.Add(vessel);
            }
        }

        return result;
    }
}
