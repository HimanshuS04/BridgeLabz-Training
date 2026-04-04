using System;
using HealthCare.Services;
using HealthCare.Interfaces;
namespace HealthCare.Menu
{
    public static class AdminMenu
    {
        public static void Show()
        {
            IAdminServices service = new AdminServices();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("---- Admin Menu ----");
                Console.WriteLine("1. Add Specialization");
                Console.WriteLine("2. View Specializations");
                Console.WriteLine("3. Update Specialization");
                Console.WriteLine("4. Delete Specialization");
                Console.WriteLine("5. View Audit Logs");
                Console.WriteLine("6. View Audit By Table");
                Console.WriteLine("7. View Audit By Operation");
                Console.WriteLine("8. Backup Database");
                Console.WriteLine("9. Restore Database");
                Console.WriteLine("0. Back");
                Console.Write("Choice: ");

                switch (Console.ReadLine())
                {
                    case "1": service.AddSpecialization(); break;
                    case "2": service.ViewSpecializations(); break;
                    case "3": service.UpdateSpecialization(); break;
                    case "4": service.DeleteSpecialization(); break;
                    case "5": service.ViewAuditLogs(); break;
                    case "6": service.ViewAuditByTable(); break;
                    case "7": service.ViewAuditByOperation(); break;
                    case "8": service.BackupDatabase(); break;
                    case "9": service.RestoreDatabase(); break;
                    case "0": return;
                    default: Console.WriteLine(" Invalid choice"); break;
                }

                Console.WriteLine("\nPress ENTER to continue...");
                Console.ReadLine();
            }
        }
    }
}
