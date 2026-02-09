using System;
using System.Data;
using Microsoft.Data.SqlClient;
using HealthCare.DB;
using HealthCare.Exceptions;
using HealthCare.Interfaces;

namespace HealthCare.Services
{
    public class VisitServices : IVisitServices
    {
        public void RecordVisit()
        {
            using SqlConnection conn = DbHelper.GetConnection();
            using SqlCommand cmd = new SqlCommand("sp_insert_visit", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            Console.Write("Appointment ID: ");
            cmd.Parameters.AddWithValue("@appointment_id", int.Parse(Console.ReadLine()));

            Console.Write("Patient ID: ");
            cmd.Parameters.AddWithValue("@patient_id", int.Parse(Console.ReadLine()));

            Console.Write("Doctor ID: ");
            cmd.Parameters.AddWithValue("@doctor_id", int.Parse(Console.ReadLine()));

            Console.Write("Diagnosis: ");
            cmd.Parameters.AddWithValue("@diagnosis", Console.ReadLine());

            Console.Write("Notes: ");
            cmd.Parameters.AddWithValue("@notes", Console.ReadLine());

            object id = cmd.ExecuteScalar();
            if (id == null) throw new ClinicException("Visit failed.");

            Console.WriteLine($"✅ Visit recorded (ID: {id})");
        }

        public void ViewVisitHistory()
        {
            using SqlConnection conn = DbHelper.GetConnection();
            using SqlCommand cmd = new SqlCommand("SELECT * FROM visits", conn);

            using SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                Console.WriteLine($"{r["visit_id"]}: {r["diagnosis"]}");
            }
        }

        public void UpdateVisitNotes()
        {
            using SqlConnection conn = DbHelper.GetConnection();
            using SqlCommand cmd = new SqlCommand("sp_update_visit", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            Console.Write("Visit ID: ");
            cmd.Parameters.AddWithValue("@visit_id", int.Parse(Console.ReadLine()));

            Console.Write("Diagnosis: ");
            cmd.Parameters.AddWithValue("@diagnosis", Console.ReadLine());

            Console.Write("Notes: ");
            cmd.Parameters.AddWithValue("@notes", Console.ReadLine());

            int rows = Convert.ToInt32(cmd.ExecuteScalar());
            if (rows == 0) ClinicException.NotFound("Visit");

            Console.WriteLine("✅ Visit updated");
        }
    }
}
