using System;

public class AmbulanceRouteMenu
{
    private IAmbulanceRoute route = new AmbulanceRouteUtilityImpl();

    public void ShowMenu()
    {
        int choice;
        do
        {
            Console.WriteLine("\n1. Display Hospital Units");
            Console.WriteLine("2. Find Next Available Unit");
            Console.WriteLine("3. Toggle Unit Availability");
            Console.WriteLine("4. Remove Unit (Maintenance)");
            Console.WriteLine("5. Exit");

            Console.Write("Enter choice: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    route.DisplayUnits();
                    break;
                case 2:
                    route.FindNextAvailableUnit();
                    break;
                case 3:
                    route.ToggleAvailability();
                    break;
                case 4:
                    route.RemoveUnit();
                    break;
            }

        } while (choice != 5);
    }
}
