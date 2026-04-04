public static class CacheManager
{
    public static Dictionary<int, Account> Accounts =
        new Dictionary<int, Account>();

    public static void LoadSampleData()
    {
        Accounts[1] = new Account
        {
            AccountId = 1,
            HolderName = "Himanshu",
            Balance = 5000
        };
    }
}
