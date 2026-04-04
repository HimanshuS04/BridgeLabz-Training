using System;
using HealthCare.Services;
using HealthCare.Interfaces;

namespace HealthCare.Menu
{
    public static class PatientMenu
    {
        public static void Show()
        {
            IPatientService service = new PatientService();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("---- Patient Menu ----");
                Console.WriteLine("1. Register Patient");
                Console.WriteLine("2. Update Patient");
                Console.WriteLine("3. Search Patient");
                Console.WriteLine("4. View Visit History");
                Console.WriteLine("0. Back");
                Console.Write("Choice: ");

                switch (Console.ReadLine())
                {
                    case "1": service.RegisterPatient(); break;
                    case "2": service.UpdatePatient(); break;
                    case "3": service.SearchPatient(); break;
                    case "4": service.ViewVisitHistory(); break;
                    case "0": return;
                    default: Console.WriteLine("❌ Invalid choice"); break;
                }

                Console.WriteLine("\nPress ENTER to continue...");
                Console.ReadLine();
            }
        }
    }
}
