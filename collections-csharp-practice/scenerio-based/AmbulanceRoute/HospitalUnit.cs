using System;
public class HospitalUnit
{
    private string UnitName;
    private bool Available;
    public HospitalUnit(string unitName, bool available)
    {
        UnitName = unitName;
        Available = available;
    }
    public string GetUnitName()
    {
        return UnitName;
    }
    public void SetUnitName(string unitName)
    {
        UnitName = unitName;
    }
    public bool IsAvailable()
    {
        return Available;
    }
    public void SetAvailable(bool available)
    {
        Available = available;
    }
    public override string ToString()
    {
        return UnitName + " | Available: " + Available;
    }
}