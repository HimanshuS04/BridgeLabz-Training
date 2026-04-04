interface IRodCuttingService
{
    int CalculateOptimizedRevenue(int length);
    int CalculateNonOptimizedRevenue();
    void AddCustomPrice(int length, int price);
}
