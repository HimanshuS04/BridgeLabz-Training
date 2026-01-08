using System;

public class SmartHomeUtilityImpl : IControllable
{
    public void ControlAppliance(Appliance[] appliances, int choice, bool turnOn)
    {
        if (choice < 1 || choice > appliances.Length)
        {
            Console.WriteLine("Invalid appliance selection");
            return;
        }

        Appliance appliance = appliances[choice - 1];
        appliance.SetStatus(turnOn);

        switch (appliance.GetType())
        {
            case "Light":
                Console.WriteLine(turnOn
                    ? "Light turned ON very Brightly"
                    : "Light turned OFF");
                break;

            case "Fan":
                Console.WriteLine(turnOn
                    ? "Fan started at highest speed"
                    : "Fan turned OFF");
                break;

            case "AC":
                Console.WriteLine(turnOn
                    ? "AC cooling room to 16°C"
                    : "AC turned OFF");
                break;

            default:
                Console.WriteLine("Unknown appliance");
                break;
        }
    }
}
