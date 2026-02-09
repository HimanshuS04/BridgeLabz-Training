using System;
using System.Data;
using Microsoft.Data.SqlClient;
using HealthCare.DB;
using HealthCare.Exceptions;
using HealthCare.Interfaces;

namespace HealthCare.Services
{
    public class AppointmentServices : IAppointmentServices
    {
        public void BookAppointment()
        {
            using SqlConnection conn = DbHelper.GetConnection();
            using SqlCommand cmd = new SqlCommand("sp_insert_appointment", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            Console.Write("Patient ID: ");
            cmd.Parameters.AddWithValue("@patient_id", int.Parse(Console.ReadLine()));

            Console.Write("Doctor ID: ");
            cmd.Parameters.AddWithValue("@doctor_id", int.Parse(Console.ReadLine()));

            Console.Write("Time (HH:mm): ");
            cmd.Parameters.AddWithValue("@appointment_time", TimeSpan.Parse(Console.ReadLine()));

            object id = cmd.ExecuteScalar();
            if (id == null) throw new ClinicException("Appointment failed.");

            Console.WriteLine($"✅ Appointment booked (ID: {id})");
        }

        public void ViewAppointments()
        {
            using SqlConnection conn = DbHelper.GetConnection();
            using SqlCommand cmd = new SqlCommand("SELECT * FROM appointments", conn);

            using SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                Console.WriteLine($"#{r["appointment_id"]} {r["status"]}");
            }
        }

        public void CancelAppointment()
        {
            using SqlConnection conn = DbHelper.GetConnection();
            using SqlCommand cmd = new SqlCommand("sp_delete_appointment", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            Console.Write("Appointment ID: ");
            cmd.Parameters.AddWithValue("@appointment_id", int.Parse(Console.ReadLine()));

            int rows = Convert.ToInt32(cmd.ExecuteScalar());
            if (rows == 0) ClinicException.NotFound("Appointment");

            Console.WriteLine("✅ Appointment cancelled");
        }

        public void UpdateAppointmentStatus()
        {
            Console.WriteLine("Handled via Visit completion (DB trigger)");
        }
    }
}
