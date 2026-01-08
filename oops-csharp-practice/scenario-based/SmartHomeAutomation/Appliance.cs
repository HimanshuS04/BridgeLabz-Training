using System;
public class Appliance
{
    private int ApplianceId{get; set;}
    private string ApplianceName{get; set;}
    private string Type{get; set;}
    private bool IsOn{get; set;}

    public void SetApplianceId(int id)
    {
        ApplianceId = id;
    }

    public int GetApplianceId()
    {
        return ApplianceId;
    }

    public void SetApplianceName(string name)
    {
        ApplianceName = name;
    }
    public string GetApplianceName()
    {
        return ApplianceName;
    }
    public void SetType(string type)
    {
        Type = type;
    }
    public string GetType()
    {
        return Type;
    }
    public void SetStatus(bool status)
    {
        IsOn = status;
    }
    public bool GetStatus()
    {
        return IsOn;
    }

    public override string ToString()
    {
        return $"{ApplianceId,-4} {ApplianceName,-20} {Type,-8} {(IsOn ? "ON" : "OFF")}";
    }
}