using System;

class RodCuttingUtilityImpl : IRodCuttingService
{
    private Rod rod;
      public void SetRod(Rod rod)
    {
        this.rod = rod;
    }

    
    public int CalculateOptimizedRevenue(int length)
    {
        if (length == 0)
            return 0;

        int maxRevenue = 0;
        int[] prices = rod.GetPrices();

        for (int cut = 1; cut <= length; cut++)
        {
            int revenue =
                prices[cut] +
                CalculateOptimizedRevenue(length - cut);

            if (revenue > maxRevenue)
                maxRevenue = revenue;
        }

        return maxRevenue;
    }

    public int CalculateNonOptimizedRevenue()
    {
        return rod.GetPrices()[rod.GetLength()];
    }

    public void AddCustomPrice(int length, int price)
    {
        rod.GetPrices()[length] = price;
    }
}
