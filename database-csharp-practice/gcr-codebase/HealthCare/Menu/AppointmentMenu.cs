using System;
using HealthCare.Services;
using HealthCare.Interfaces;
namespace HealthCare.Menu
{
    public static class AppointmentMenu
    {
        public static void Show()
        {
            IAppointmentServices service = new AppointmentServices();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("---- Appointment Menu ----");
                Console.WriteLine("1. Book Appointment");
                Console.WriteLine("2. View Appointments");
                Console.WriteLine("3. Cancel Appointment");
                Console.WriteLine("0. Back");
                Console.Write("Choice: ");

                switch (Console.ReadLine())
                {
                    case "1": service.BookAppointment(); break;
                    case "2": service.ViewAppointments(); break;
                    case "3": service.CancelAppointment(); break;
                    case "0": return;
                    default: Console.WriteLine("❌ Invalid choice"); break;
                }

                Console.WriteLine("\nPress ENTER to continue...");
                Console.ReadLine();
            }
        }
    }
}
