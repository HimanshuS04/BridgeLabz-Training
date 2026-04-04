using System;
using System.Data;
using Microsoft.Data.SqlClient;
using HealthCare.DB;
using HealthCare.Exceptions;
using HealthCare.Interfaces;

namespace HealthCare.Services
{
    public class AdminServices : IAdminServices
    {
        public void AddSpecialization()
        {
            using SqlConnection conn = DbHelper.GetConnection();
            using SqlCommand cmd = new SqlCommand("sp_insert_specialty", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            Console.Write("Specialty Name: ");
            cmd.Parameters.AddWithValue("@specialty_name", Console.ReadLine());

            object id = cmd.ExecuteScalar();
            if (id == null) throw new ClinicException("Specialty insert failed.");

            Console.WriteLine("✅ Specialty added");
        }

        public void ViewSpecializations()
        {
            using SqlConnection conn = DbHelper.GetConnection();
            using SqlCommand cmd = new SqlCommand("SELECT * FROM specialties", conn);

            using SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                Console.WriteLine($"{r["specialty_id"]} - {r["specialty_name"]}");
            }
        }

        public void UpdateSpecialization()
        {
            using SqlConnection conn = DbHelper.GetConnection();
            using SqlCommand cmd = new SqlCommand("sp_update_specialty", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            Console.Write("ID: ");
            cmd.Parameters.AddWithValue("@specialty_id", int.Parse(Console.ReadLine()));

            Console.Write("Name: ");
            cmd.Parameters.AddWithValue("@specialty_name", Console.ReadLine());

            int rows = Convert.ToInt32(cmd.ExecuteScalar());
            if (rows == 0) ClinicException.NotFound("Specialty");

            Console.WriteLine("✅ Specialty updated");
        }

        public void DeleteSpecialization()
        {
            using SqlConnection conn = DbHelper.GetConnection();
            using SqlCommand cmd = new SqlCommand("sp_delete_specialty", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            Console.Write("ID: ");
            cmd.Parameters.AddWithValue("@specialty_id", int.Parse(Console.ReadLine()));

            int rows = Convert.ToInt32(cmd.ExecuteScalar());
            if (rows == 0) ClinicException.NotFound("Specialty");

            Console.WriteLine("✅ Specialty deleted");
        }

        public void ViewAuditLogs()
        {
            using SqlConnection conn = DbHelper.GetConnection();
            using SqlCommand cmd = new SqlCommand("SELECT * FROM audit_log ORDER BY changed_at DESC", conn);

            using SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                Console.WriteLine($"{r["table_name"]} {r["action"]} {r["changed_at"]}");
            }
        }

        public void ViewAuditByTable()
        {
            Console.Write("Table Name: ");
            string table = Console.ReadLine();

            using SqlConnection conn = DbHelper.GetConnection();
            using SqlCommand cmd = new SqlCommand(
                "SELECT * FROM audit_log WHERE table_name=@t", conn);

            cmd.Parameters.AddWithValue("@t", table);

            using SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                Console.WriteLine($"{r["action"]} {r["changed_at"]}");
            }
        }

        public void ViewAuditByOperation()
        {
            Console.Write("Operation (INSERT/UPDATE/DELETE): ");
            string op = Console.ReadLine();

            using SqlConnection conn = DbHelper.GetConnection();
            using SqlCommand cmd = new SqlCommand(
                "SELECT * FROM audit_log WHERE action=@a", conn);

            cmd.Parameters.AddWithValue("@a", op);

            using SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                Console.WriteLine($"{r["table_name"]} {r["changed_at"]}");
            }
        }

        public void BackupDatabase()
        {
            using SqlConnection conn = DbHelper.GetMasterConnection();
            using SqlCommand cmd = new SqlCommand(
                "BACKUP DATABASE HealthCareDB TO DISK='C:\\HealthCareDB.bak'", conn);

            cmd.ExecuteNonQuery();
            Console.WriteLine("✅ Backup completed");
        }

        public void RestoreDatabase()
        {
            using SqlConnection conn = DbHelper.GetMasterConnection();
            using SqlCommand cmd = new SqlCommand(
                "RESTORE DATABASE HealthCareDB FROM DISK='C:\\HealthCareDB.bak' WITH REPLACE", conn);

            cmd.ExecuteNonQuery();
            Console.WriteLine("✅ Restore completed");
        }
    }
}
