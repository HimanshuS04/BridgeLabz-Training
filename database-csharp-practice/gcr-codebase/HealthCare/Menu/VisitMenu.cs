using System;
using HealthCare.Services;
using HealthCare.Interfaces;
namespace HealthCare.Menu
{
    public static class VisitMenu
    {
        public static void Show()
        {
            IVisitServices service = new VisitServices();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("---- Visit Menu ----");
                Console.WriteLine("1. Record Visit");
                Console.WriteLine("2. View Visit History");
                Console.WriteLine("3. Update Visit Notes");
                Console.WriteLine("0. Back");
                Console.Write("Choice: ");

                switch (Console.ReadLine())
                {
                    case "1": service.RecordVisit(); break;
                    case "2": service.ViewVisitHistory(); break;
                    case "3": service.UpdateVisitNotes(); break;
                    case "0": return;
                    default: Console.WriteLine("❌ Invalid choice"); break;
                }

                Console.WriteLine("\nPress ENTER to continue...");
                Console.ReadLine();
            }
        }
    }
}
