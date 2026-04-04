using System;
using System.Data.SqlTypes;
using Microsoft.Data.SqlClient;
class PracticeDataConnection:IPracticeDataConnection
{
    public  void GetAllStudents()
    {
        using SqlConnection conn = DataConfig.GetConnection();
        string query="Select * from student_records";
        SqlCommand command=new SqlCommand(query,conn);
        SqlDataReader reader= command.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine(
                $"ID: {reader["student_id"]}"+
                $"Name:{reader["student_name"]}"+
                $"Marks{reader["marks"]}"
            );
        }
    }

    public void InsertStudent()
    {
        Console.WriteLine("Enter id of student");
        int id= int.Parse(Console.ReadLine());
        Console.WriteLine("Enter Name of student");
        string name = Console.ReadLine();
        Console.WriteLine("Enter marks of student");
        int marks= int.Parse(Console.ReadLine());
        Console.WriteLine("Enter departtment id of student");
        int dept_id= int.Parse(Console.ReadLine());
        string query=@"Insert into student_records(student_id,student_name,marks,dept_id) Values(@id,@name,@marks,@dept_id)";
        using SqlConnection conn = DataConfig.GetConnection();
        SqlCommand command= new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@id",id);
            command.Parameters.AddWithValue("@name",name);
            command.Parameters.AddWithValue("@marks",marks);
            command.Parameters.AddWithValue("@dept_id",dept_id);

            command.ExecuteNonQuery();
            Console.WriteLine("insert data succesfully");
    }
    public void UpdateStudentMark()
    {
        Console.WriteLine("Enter id of student");
        int id= int.Parse(Console.ReadLine());
        Console.WriteLine("Enter updated marks of student");
        int marks= int.Parse(Console.ReadLine());
        string query=@"Update student_records Set marks=@marks Where student_id=@id";
        SqlConnection conn=DataConfig.GetConnection();
        SqlCommand cmd= new SqlCommand(query,conn);
        cmd.Parameters.AddWithValue("@id",id);
        cmd.Parameters.AddWithValue("@marks",marks);
        cmd.ExecuteNonQuery();

        Console.WriteLine($"updated marks for id:{id} is {marks}");
    }
    public void DeleteStudent()
    {
        Console.WriteLine("Enter student id to delete");
        int id=int.Parse(Console.ReadLine());
        string query=@"Delete from student_records where student_id=@id";
        SqlConnection conn= DataConfig.GetConnection();
        SqlCommand cmd= new SqlCommand(query,conn);
        cmd.Parameters.AddWithValue("@id",id);
        cmd.ExecuteNonQuery();

        Console.WriteLine($"Student data deleted with id {id}");
    }
}