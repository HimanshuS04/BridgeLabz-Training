using System;
public class WoodServiceImpl : IWoodService
{
    private GlobalLinkedList priceList = new GlobalLinkedList();

    public void InitializePriceChart()
    {
        AddRod(1, 3);
        AddRod(2, 6);
        AddRod(3, 8);
        AddRod(4, 10);
        AddRod(6, 15);
        AddRod(12, 30);
    }

    private void AddRod(int length, int price)
    {
        WoodRod rod = new WoodRod();
        rod.SetLength(length);
        rod.SetPrice(price);

        priceList.AddLast(rod);
    }

    // Scenario A
    public int GetMaxRevenue(int rodLength)
    {
        if (rodLength == 0)
            return 0;

        int maxRevenue = 0;
        GlobalLinkedList.Node temp = priceList.GetHead();

        while (temp != null)
        {
            WoodRod rod = (WoodRod)temp.GetData();

            if (rod.GetLength() <= rodLength)
            {
                int revenue =
                    rod.GetPrice() +
                    GetMaxRevenue(rodLength - rod.GetLength());

                if (revenue > maxRevenue)
                    maxRevenue = revenue;
            }

            temp = temp.GetNext();
        }

        return maxRevenue;
    }

    // Scenario B
    public int GetRevenueWithWaste(int rodLength, int allowedWaste)
    {
        if (rodLength <= allowedWaste)
            return 0;

        int maxRevenue = 0;
        GlobalLinkedList.Node temp = priceList.GetHead();

        while (temp != null)
        {
            WoodRod rod = (WoodRod)temp.GetData();
            int remaining = rodLength - rod.GetLength();

            if (remaining >= 0 && remaining <= allowedWaste)
            {
                int revenue =
                    rod.GetPrice() +
                    GetRevenueWithWaste(remaining, allowedWaste);

                if (revenue > maxRevenue)
                    maxRevenue = revenue;
            }

            temp = temp.GetNext();
        }

        return maxRevenue;
    }

    // Scenario C
    public void SuggestBestCut(int rodLength, int allowedWaste)
    {
        int bestRevenue = 0;
        int bestWaste = rodLength;

        GlobalLinkedList.Node temp = priceList.GetHead();

        while (temp != null)
        {
            WoodRod rod = (WoodRod)temp.GetData();
            int remaining = rodLength - rod.GetLength();

            if (remaining >= 0)
            {
                int revenue =
                    rod.GetPrice() +
                    GetRevenueWithWaste(remaining, allowedWaste);

                if (revenue > bestRevenue ||
                   (revenue == bestRevenue && remaining < bestWaste))
                {
                    bestRevenue = revenue;
                    bestWaste = remaining;
                }
            }

            temp = temp.GetNext();
        }

        Console.WriteLine($"Best Revenue: ₹{bestRevenue}");
        Console.WriteLine($"Waste Left: {bestWaste} ft");
    }
}
