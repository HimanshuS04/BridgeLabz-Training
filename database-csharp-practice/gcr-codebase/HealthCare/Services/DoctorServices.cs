using System;
using System.Data;
using Microsoft.Data.SqlClient;
using HealthCare.DB;
using HealthCare.Exceptions;
using HealthCare.Interfaces;

namespace HealthCare.Services
{
    public class DoctorServices : IDoctorServices
    {
        public void AddDoctor()
        {
            using SqlConnection conn = DbHelper.GetConnection();
            using SqlCommand cmd = new SqlCommand("sp_insert_doctor", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            Console.Write("Name: ");
            cmd.Parameters.AddWithValue("@name", Console.ReadLine());

            Console.Write("Specialty ID: ");
            cmd.Parameters.AddWithValue("@specialty_id", int.Parse(Console.ReadLine()));

            Console.Write("Contact: ");
            cmd.Parameters.AddWithValue("@contact", Console.ReadLine());

            Console.Write("Fee: ");
            cmd.Parameters.AddWithValue("@consultation_fee", decimal.Parse(Console.ReadLine()));

            object id = cmd.ExecuteScalar();
            if (id == null) throw new ClinicException("Doctor creation failed.");

            Console.WriteLine($"✅ Doctor added (ID: {id})");
        }

        public void UpdateDoctor()
        {
            using SqlConnection conn = DbHelper.GetConnection();
            using SqlCommand cmd = new SqlCommand("sp_update_doctor", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            Console.Write("Doctor ID: ");
            cmd.Parameters.AddWithValue("@doctor_id", int.Parse(Console.ReadLine()));

            Console.Write("Name: ");
            cmd.Parameters.AddWithValue("@name", Console.ReadLine());

            Console.Write("Specialty ID: ");
            cmd.Parameters.AddWithValue("@specialty_id", int.Parse(Console.ReadLine()));

            Console.Write("Contact: ");
            cmd.Parameters.AddWithValue("@contact", Console.ReadLine());

            Console.Write("Fee: ");
            cmd.Parameters.AddWithValue("@consultation_fee", decimal.Parse(Console.ReadLine()));

            Console.Write("Active (1/0): ");
            cmd.Parameters.AddWithValue("@is_active", int.Parse(Console.ReadLine()));

            int rows = Convert.ToInt32(cmd.ExecuteScalar());
            if (rows == 0) ClinicException.NotFound("Doctor");

            Console.WriteLine("✅ Doctor updated");
        }

        public void ViewDoctorsBySpecialty()
        {
            using SqlConnection conn = DbHelper.GetConnection();
            using SqlCommand cmd = new SqlCommand(
                "SELECT * FROM doctors WHERE specialty_id=@sid AND is_active=1", conn);

            Console.Write("Specialty ID: ");
            cmd.Parameters.AddWithValue("@sid", int.Parse(Console.ReadLine()));

            using SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                Console.WriteLine($"{r["doctor_id"]} - {r["name"]}");
            }
        }

        public void DeactivateDoctor()
        {
            using SqlConnection conn = DbHelper.GetConnection();
            using SqlCommand cmd = new SqlCommand(
                "UPDATE doctors SET is_active=0 WHERE doctor_id=@id", conn);

            Console.Write("Doctor ID: ");
            cmd.Parameters.AddWithValue("@id", int.Parse(Console.ReadLine()));

            int rows = cmd.ExecuteNonQuery();
            if (rows == 0) ClinicException.NotFound("Doctor");

            Console.WriteLine("✅ Doctor deactivated");
        }
    }
}
