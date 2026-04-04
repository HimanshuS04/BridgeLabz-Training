public class Menu
{
    private ITransactionService service = new TransactionUtility();

    public void Show()
    {
        while (true)
        {
            Console.WriteLine("1. Withdraw");
            Console.WriteLine("2. Simulate 50 Parallel Withdrawals");
            Console.WriteLine("3. Exit");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                {
                    Console.Write("Enter Account Id: ");
                    int accId = int.Parse(Console.ReadLine());

                    Console.Write("Enter Amount per withdrawal: ");
                    decimal amount = decimal.Parse(Console.ReadLine());
                    service.Withdraw(accId,amount);
                    break;

                }
                case 2:
                {
                    Console.Write("Enter Account Id: ");
                    int accId = int.Parse(Console.ReadLine());
                    Console.Write("Enter Amount per withdrawal: ");
                    decimal amount = decimal.Parse(Console.ReadLine());
                    SimulateParallelWithdrawals(accId, amount);
                    break;
                }
                case 3:
                    return;
            }
        }
    }

    private void SimulateParallelWithdrawals(int accId,decimal amount)
    {
        Parallel.For(0, 50, i =>
        {
            service.Withdraw(accId,amount);
        });

        Console.WriteLine("Final Balance: " +
            CacheManager.Accounts[1].Balance);
    }
}
