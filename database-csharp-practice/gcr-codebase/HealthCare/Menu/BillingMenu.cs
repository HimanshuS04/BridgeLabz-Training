using System;
using HealthCare.Services;
using HealthCare.Interfaces;
namespace HealthCare.Menu
{
    public static class BillingMenu
    {
        public static void Show()
        {
            IBillingServices service = new BillServices();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("---- Billing Menu ----");
                Console.WriteLine("1. Generate Bill");
                Console.WriteLine("2. View Bills");
                Console.WriteLine("3. Make Payment");
                Console.WriteLine("4. Payment History");
                Console.WriteLine("0. Back");
                Console.Write("Choice: ");

                switch (Console.ReadLine())
                {
                    case "1": service.GenerateBill(); break;
                    case "2": service.ViewBillDetails(); break;
                    case "3": service.MakePayment(); break;
                    case "4": service.ViewPaymentHistory(); break;
                    case "0": return;
                    default: Console.WriteLine("❌ Invalid choice"); break;
                }

                Console.WriteLine("\nPress ENTER to continue...");
                Console.ReadLine();
            }
        }
    }
}
