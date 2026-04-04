using System;

public class SmartHomeMenu
{
    private IControllable service;
    private Appliance[] appliances;

    public void SetAppliances(Appliance[] applianceArray)
    {
        appliances = applianceArray;
    }
    public void SetService(IControllable controllable)
    {
        service = controllable;
    }

   

    public void ShowMenu()
    {
        Console.WriteLine(" Smart Home Menu ");
        Console.WriteLine("1 Light");
        Console.WriteLine("2 Fan");
        Console.WriteLine("3 AC");
        Console.WriteLine("4 Exit");
        Console.Write("Select appliance: ");

        int.TryParse(Console.ReadLine(), out int applianceChoice);

        if (applianceChoice == 4)
            return;

        Console.Write("1-> Turn ON  2-> Turn OFF : ");
        int.TryParse(Console.ReadLine(), out int action);

        bool turnOn = action == 1;

        service.ControlAppliance(appliances, applianceChoice, turnOn);
    }
}
