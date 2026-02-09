using System;

namespace HealthCare.Menu
{
    public class MainMenu
    {
        public static void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=======================================");
                Console.WriteLine("   HEALTH CARE MANAGEMENT SYSTEM");
                Console.WriteLine("=======================================");
                Console.WriteLine("1. Patient Management");
                Console.WriteLine("2. Doctor Management");
                Console.WriteLine("3. Appointment Management");
                Console.WriteLine("4. Visit Management");
                Console.WriteLine("5. Billing Management");
                Console.WriteLine("6. Admin Module");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");

                switch (Console.ReadLine())
                {
                    case "1": PatientMenu.Show(); break;
                    case "2": DoctorMenu.Show(); break;
                    case "3": AppointmentMenu.Show(); break;
                    case "4": VisitMenu.Show(); break;
                    case "5": BillingMenu.Show(); break;
                    case "6": AdminMenu.Show(); break;
                    case "0": return;
                    default:
                        Console.WriteLine("Invalid choice!");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}
