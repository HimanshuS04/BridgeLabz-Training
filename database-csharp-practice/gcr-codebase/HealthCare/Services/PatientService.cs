using System;
using System.Data;
using Microsoft.Data.SqlClient;
using HealthCare.DB;
using HealthCare.Exceptions;
using HealthCare.Interfaces;

namespace HealthCare.Services
{
    public class PatientService : IPatientService
    {
        public void RegisterPatient()
        {
            using SqlConnection conn = DbHelper.GetConnection();
            using SqlCommand cmd = new SqlCommand("sp_insert_patient", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            Console.Write("Name: ");
            cmd.Parameters.AddWithValue("@name", Console.ReadLine());

            Console.Write("DOB (yyyy-mm-dd): ");
            cmd.Parameters.AddWithValue("@dob", DateTime.Parse(Console.ReadLine()));

            Console.Write("Contact: ");
            cmd.Parameters.AddWithValue("@contact", Console.ReadLine());

            Console.Write("Email: ");
            cmd.Parameters.AddWithValue("@email", Console.ReadLine());

            Console.Write("Address: ");
            cmd.Parameters.AddWithValue("@address", Console.ReadLine());

            Console.Write("Blood Group: ");
            cmd.Parameters.AddWithValue("@blood_group", Console.ReadLine());

            object id = cmd.ExecuteScalar();
            if (id == null) throw new ClinicException("Patient registration failed.");

            Console.WriteLine($"✅ Patient registered (ID: {id})");
        }

        public void UpdatePatient()
        {
            using SqlConnection conn = DbHelper.GetConnection();
            using SqlCommand cmd = new SqlCommand("sp_update_patient", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            Console.Write("Patient ID: ");
            cmd.Parameters.AddWithValue("@patient_id", int.Parse(Console.ReadLine()));

            Console.Write("Name: ");
            cmd.Parameters.AddWithValue("@name", Console.ReadLine());

            Console.Write("DOB: ");
            cmd.Parameters.AddWithValue("@dob", DateTime.Parse(Console.ReadLine()));

            Console.Write("Contact: ");
            cmd.Parameters.AddWithValue("@contact", Console.ReadLine());

            Console.Write("Email: ");
            cmd.Parameters.AddWithValue("@email", Console.ReadLine());

            Console.Write("Address: ");
            cmd.Parameters.AddWithValue("@address", Console.ReadLine());

            Console.Write("Blood Group: ");
            cmd.Parameters.AddWithValue("@blood_group", Console.ReadLine());

            int rows = Convert.ToInt32(cmd.ExecuteScalar());
            if (rows == 0) ClinicException.NotFound("Patient");

            Console.WriteLine("✅ Patient updated successfully");
        }

        public void SearchPatient()
        {
            using SqlConnection conn = DbHelper.GetConnection();
            using SqlCommand cmd = new SqlCommand(
                "SELECT * FROM patients WHERE patient_id = @id", conn);

            Console.Write("Patient ID: ");
            cmd.Parameters.AddWithValue("@id", int.Parse(Console.ReadLine()));

            using SqlDataReader reader = cmd.ExecuteReader();
            if (!reader.Read()) ClinicException.NotFound("Patient");

            Console.WriteLine($"Name: {reader["name"]}");
            Console.WriteLine($"Contact: {reader["contact"]}");
            Console.WriteLine($"Email: {reader["email"]}");
        }

        public void ViewVisitHistory()
        {
            using SqlConnection conn = DbHelper.GetConnection();
            using SqlCommand cmd = new SqlCommand(
                "SELECT * FROM visits WHERE patient_id = @pid", conn);

            Console.Write("Patient ID: ");
            cmd.Parameters.AddWithValue("@pid", int.Parse(Console.ReadLine()));

            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"Visit {reader["visit_id"]}: {reader["diagnosis"]}");
            }
        }
    }
}
