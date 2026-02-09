using System;
using HealthCare.Services;
using HealthCare.Interfaces;
namespace HealthCare.Menu
{
    public static class DoctorMenu
    {
        public static void Show()
        {
            IDoctorServices service = new DoctorServices();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("---- Doctor Menu ----");
                Console.WriteLine("1. Add Doctor");
                Console.WriteLine("2. Update Doctor");
                Console.WriteLine("3. View Doctors By Specialty");
                Console.WriteLine("4. Deactivate Doctor");
                Console.WriteLine("0. Back");
                Console.Write("Choice: ");

                switch (Console.ReadLine())
                {
                    case "1": service.AddDoctor(); break;
                    case "2": service.UpdateDoctor(); break;
                    case "3": service.ViewDoctorsBySpecialty(); break;
                    case "4": service.DeactivateDoctor(); break;
                    case "0": return;
                    default: Console.WriteLine("❌ Invalid choice"); break;
                }

                Console.WriteLine("\nPress ENTER to continue...");
                Console.ReadLine();
            }
        }
    }
}
