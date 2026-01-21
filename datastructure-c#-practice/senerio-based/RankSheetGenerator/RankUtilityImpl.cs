using System;
public class RankUtilityImpl : IRankService
{
    private Student[] students;
    private int count;

    public RankUtilityImpl()
    {
        students = new Student[20];
        count = 0;

        students[count++] = new Student(1, "Arjun", 95, "Delhi");
        students[count++] = new Student(2, "Riya", 88, "Delhi");

        students[count++] = new Student(3, "Sourabh", 92, "Noida");
        students[count++] = new Student(4, "Katrina", 85, "Noida");

        students[count++] = new Student(5, "Aditya", 90, "Agra");
        students[count++] = new Student(6, "Chamcham", 80, "Agra");
    }

    // Add Student Function
    public void AddStudent()
    {
        if (count >= students.Length)
        {
            System.Console.WriteLine("Student list is full.");
            return;
        }

        Console.Write("Enter Roll No: ");
        int roll = int.Parse(Console.ReadLine());

        // Duplicate roll check
        for (int i = 0; i < count; i++)
        {
            if (students[i].GetRollNum() == roll)
            {
                Console.WriteLine("Roll number already exists.");
                return;
            }
        }

        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Marks: ");
        int marks = int.Parse(Console.ReadLine());

        Console.Write("Enter District: ");
        string district = Console.ReadLine();

        students[count++] = new Student(roll, name, marks, district);

        Console.WriteLine("Student added successfully.");
    }

    //  Display Students
    public void DisplayAll()
    {
        if (count == 0)
        {
            Console.WriteLine("No students available.");
            return;
        }

        for (int i = 0; i < count; i++)
        {
            Console.WriteLine(students[i]);
        }
    }

    //  Generate Rank List
    public void GenerateRankList()
    {
        if (count == 0)
        {
            Console.WriteLine("No students to rank.");
            return;
        }

        MergeSort(students, 0, count - 1);

        Console.WriteLine("\n=== STATE-WISE RANK LIST ===");
        DisplayAll();
    }

    // Merge Sort
    private void MergeSort(Student[] arr, int left, int right)
    {
        if (left < right)
        {
            int mid = (left + right) / 2;

            MergeSort(arr, left, mid);
            MergeSort(arr, mid + 1, right);

            Merge(arr, left, mid, right);
        }
    }

    //  Stable Merge
    private void Merge(Student[] arr, int left, int mid, int right)
    {
        int n1 = mid - left + 1;
        int n2 = right - mid;

        Student[] L = new Student[n1];
        Student[] R = new Student[n2];

        for (int i = 0; i < n1; i++)
            L[i] = arr[left + i];

        for (int j = 0; j < n2; j++)
            R[j] = arr[mid + 1 + j];

        int i1 = 0, i2 = 0, k = left;

        while (i1 < n1 && i2 < n2)
        {
            // Descending order, stable for equal marks
            if (L[i1].GetMarks() >= R[i2].GetMarks())
            {
                arr[k++] = L[i1++];
            }
            else
            {
                arr[k++] = R[i2++];
            }
        }

        while (i1 < n1)
            arr[k++] = L[i1++];

        while (i2 < n2)
            arr[k++] = R[i2++];
    }
}
