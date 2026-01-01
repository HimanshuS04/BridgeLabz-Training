using System;
class Bank
{
   public double minBalance=2000;
   public string bankName;
   public int accountCount=10;
      // accountDetails[row, col]
    // col 0 → Account Number
    // col 1 → Balance
    public double[,] accountDetails = new double[10, 2]
    {
        {1001, 5000},
        {1002, 7500},
        {1003, 12000},
        {1004, 3000},
        {1005, 9800},
        {1006, 4200},
        {1007, 15000},
        {1008, 6200},
        {0,0},
        {0,0}
    };

    public string[] accountName = new string[10]
    {
        "Rahul",
        "Anita",
        "Suresh",
        "Priya",
        "Karan",
        "Neha",
        "Amit",
        "Pooja",
        "",
        ""
    };

    public bool[] isActive = new bool[10]
      {
        true,
        true,
        true,
        true,
        true,
        true,
        true,
        true,
        false,
        false
    };


   public static void Main(string[] args)
    {

        Bank bank = new Bank();
        Manager manager = new Manager();
        Customer customer = new Customer();

        while (true)
        {
            Console.WriteLine("\n--- BANK MENU ---");
            Console.WriteLine("1. Manager");
            Console.WriteLine("2. Customer");
            Console.WriteLine("3. Exit");
            Console.Write("Enter choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("\n--- MANAGER MENU ---");
                    Console.WriteLine("1. Create Account");
                    Console.WriteLine("2. Close Account");
                    Console.WriteLine("3. View Account");
                    Console.Write("Enter choice: ");
                    int mChoice = int.Parse(Console.ReadLine());

                    if (mChoice == 1)
                    {
                        Console.Write("Account No: ");
                        int accNo = int.Parse(Console.ReadLine());
                        Console.Write("Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Initial Deposit: ");
                        double dep = double.Parse(Console.ReadLine());
                        manager.CreateAccount(bank, accNo, name, dep);
                    }
                    else if (mChoice == 2)
                    {
                        Console.Write("Account No: ");
                        int accNo = int.Parse(Console.ReadLine());
                        manager.CloseAccount(bank, accNo);
                    }
                    else if (mChoice == 3)
                    {
                        Console.Write("Account No: ");
                        int accNo = int.Parse(Console.ReadLine());
                        manager.ViewAccountDetails(bank, accNo);
                    }
                    break;

                case 2:
                    Console.WriteLine("\n--- CUSTOMER MENU ---");
                    Console.WriteLine("1. Deposit");
                    Console.WriteLine("2. Withdraw");
                    Console.WriteLine("3. Check Balance");
                    Console.Write("Enter choice: ");
                    int cChoice = int.Parse(Console.ReadLine());

                    Console.Write("Account No: ");
                    int acc = int.Parse(Console.ReadLine());

                    if (cChoice == 1)
                    {
                        Console.Write("Amount: ");
                        double amt = double.Parse(Console.ReadLine());
                        customer.Deposit(bank, acc, amt);
                    }
                    else if (cChoice == 2)
                    {
                        Console.Write("Amount: ");
                        double amt = double.Parse(Console.ReadLine());
                        customer.Withdraw(bank, acc, amt);
                    }
                    else if (cChoice == 3)
                    {
                        customer.CheckBalance(bank, acc);
                    }
                    break;

                case 3:
                    Console.WriteLine("Thank you for using the bank system.");
                    return;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        } 
    }
}