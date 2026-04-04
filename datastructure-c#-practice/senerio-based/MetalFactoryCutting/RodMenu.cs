using System;

class RodMenu
{
    public void Show()
    {
        Rod rod = new Rod();
        rod.SetLength(8);
        rod.SetPrices(new int[] { 1, 3, 5, 8, 9, 11, 16, 17, 20 });

        IRodCuttingService service = new RodCuttingUtilityImpl();
        ((RodCuttingUtilityImpl)service).SetRod(rod);

        while (true)
        {
            Console.WriteLine(" Metal Factory Pipe Cutting");
            Console.WriteLine("1.Find Best Cutting Strategy");
            Console.WriteLine("2.Add Custom Length Order");
            Console.WriteLine("3. Non-Optimized Cutting Revenue");
            Console.WriteLine("4. Exit");
            Console.Write("Choose option: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Optimized Revenue: " +
                        service.CalculateOptimizedRevenue(rod.GetLength()));
                    break;

                case 2:
                    Console.Write("Enter custom length: ");
                    int len = int.Parse(Console.ReadLine());
                    Console.Write("Enter custom price: ");
                    int price = int.Parse(Console.ReadLine());

                    service.AddCustomPrice(len, price);

                    Console.WriteLine("Updated Optimized Revenue: " +
                        service.CalculateOptimizedRevenue(rod.GetLength()));
                    break;

                case 3:
                    Console.WriteLine("Revenue without optimization: " +
                        service.CalculateNonOptimizedRevenue());
                    break;

                case 4:
                    return;

                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        }
    }
}
