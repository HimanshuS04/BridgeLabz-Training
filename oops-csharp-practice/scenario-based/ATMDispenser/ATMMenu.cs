using System;
public class ATMMenu
{
    private IATMService atmService = new ATMUtilityImpl();
    public void ShowMenu()
    {
        atmService.InitializeNotes();
        int choice;
        do
        {
            Console.WriteLine("=== ATM Menu ===");
            Console.WriteLine("1. Dispense ₹880");
            Console.WriteLine("2. Remove ₹500 Notes");
            Console.WriteLine("3. Exit");
            Console.Write("Enter choice: ");

            choice = Convert.ToInt32(Console.ReadLine());

            switch(choice)
            {
                case 1:
                    atmService.DispenseAmount(880);
                    break;
                case 2:
                    atmService.RemoveFiveHundred();
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }

        }while(choice != 3);
    }
}