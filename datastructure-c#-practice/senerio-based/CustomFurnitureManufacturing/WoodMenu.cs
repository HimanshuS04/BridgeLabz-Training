using System;

public class WoodMenu
{
    private IWoodService service = new WoodServiceImpl();

    public void ShowMenu()
    {
        service.InitializePriceChart();
        int choice;

        do
        {
            Console.WriteLine(" Custom Furniture Manufacturing ");
            Console.WriteLine("1. Maximize Revenue (12 ft)");
            Console.WriteLine("2. Revenue With Waste Constraint");
            Console.WriteLine("3. Suggest Best Cut");
            Console.WriteLine("4. Exit");
            Console.Write("Enter choice: ");

            int.TryParse(Console.ReadLine(), out choice);

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Revenue: ₹" +
                        service.GetMaxRevenue(12));
                    break;

                case 2:
                    Console.Write("Allowed waste (ft): ");
                    int waste = int.Parse(Console.ReadLine());
                    Console.WriteLine("Revenue: ₹" +
                        service.GetRevenueWithWaste(12, waste));
                    break;

                case 3:
                    Console.Write("Allowed waste (ft): ");
                    int w = int.Parse(Console.ReadLine());
                    service.SuggestBestCut(12, w);
                    break;

                case 4:
                    Console.WriteLine("Exit");
                    break;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
        while (choice != 4);
    }
}
