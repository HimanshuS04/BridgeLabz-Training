using System;
public class SmartHomeMain
{
    public static void Main()
    {
        Appliance[] appliances = new Appliance[3];

        appliances[0] = CreateAppliance(1, "Room Light", "Light");
        appliances[1] = CreateAppliance(2, "Table Fan", "Fan");
        appliances[2] = CreateAppliance(3, "Central AC", "AC");

        IControllable utility = new SmartHomeUtilityImpl();

        SmartHomeMenu menu = new SmartHomeMenu();
        menu.SetService(utility);
        menu.SetAppliances(appliances);

        menu.ShowMenu();
    }

    private static Appliance CreateAppliance(int id, string name, string type)
    {
        Appliance appliance = new Appliance();
        appliance.SetApplianceId(id);
        appliance.SetApplianceName(name);
        appliance.SetType(type);
        return appliance;
    }
}
