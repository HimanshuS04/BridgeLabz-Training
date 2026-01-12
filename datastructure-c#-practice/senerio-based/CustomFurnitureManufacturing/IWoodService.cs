using System;
public interface IWoodService
{
    void InitializePriceChart();
    int GetMaxRevenue(int rodLength);
    int GetRevenueWithWaste(int rodLength, int allowedWaste);
    void SuggestBestCut(int rodLength, int allowedWaste);
}