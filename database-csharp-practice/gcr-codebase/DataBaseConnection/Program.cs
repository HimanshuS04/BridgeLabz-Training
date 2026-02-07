class Program
{
    static void Main()
    {
    IPracticeDataConnection Conn= new PracticeDataConnection();
    int choice;
    do{
        Console.WriteLine("1. View Students");
        Console.WriteLine("2. Insert Student");
        Console.WriteLine("3. Update Student Marks");
        Console.WriteLine("4. Delete Student");
        Console.WriteLine("5. Exit");
        Console.WriteLine("Enter your coice");
        choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                Conn.GetAllStudents();
                break;
            case 2:
                Conn.InsertStudent();
                break;
            case 3:
                Conn.UpdateStudentMark();
                break;
            case 4:
                Conn.DeleteStudent();
                break;
            case 5:
                Console.WriteLine("Existing");
                break;
        }
    }
    while(choice!=5);
    }
}
