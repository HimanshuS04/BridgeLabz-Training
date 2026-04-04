using System;

class EduQuiz
{
    string[,] quiz =
    {
        { "What is the capital of India?", "New Delhi" },
        { "Which keyword is used to define a class in C#?", "class" },
        { "What is the size of int in C#?", "4" },
        { "Which operator is used for logical AND?", "&&" },
        { "What does OOP stand for?", "Object Oriented Programming" },
        { "Which method is the entry point of a C# program?", "Main" },
        { "What symbol is used for single-line comments in C#?", "//" },
        { "Which data type stores true or false?", "bool" },
        { "What keyword is used to inherit a class in C#?", ":" },
        { "Which loop runs at least once?", "do-while" }
    };

    //  To store student results
    int[] studentMarks = new int[10];
    double[] studentPercentages = new double[10];
    int studentCount = 0;

    static void Main(string[] args)
    {
        EduQuiz quizApp = new EduQuiz();
        quizApp.Menu();
    }

    //  MAIN MENU
    void Menu()
    {
        while (true)
        {
            Console.WriteLine("\n=== EduQuiz Menu ===");
            Console.WriteLine("1. Teacher");
            Console.WriteLine("2. Student");
            Console.WriteLine("3. Exit");
            Console.Write("Enter choice: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    TeacherMenu();
                    break;

                case 2:
                    StudentAns();
                    break;

                case 3:
                    Console.WriteLine("Exiting...");
                    return;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }

    //  STUDENT QUIZ
    void StudentAns()
    {
        string[] ans = new string[quiz.GetLength(0)];
        Console.WriteLine("\n--- Quiz Started ---");

        for (int i = 0; i < quiz.GetLength(0); i++)
        {
            Console.WriteLine("Q" + (i + 1) + ": " + quiz[i, 0]);
            Console.Write("Enter answer: ");
            ans[i] = Console.ReadLine();
        }

        int marks = StudentMarks(ans);
        ShowFeedback(ans);

        double percentage = ShowResult(marks, quiz.GetLength(0));

        // Store result for teacher
        studentMarks[studentCount] = marks;
        studentPercentages[studentCount] = percentage;
        studentCount++;
    }

    int StudentMarks(string[] stuAns)
    {
        int marks = 0;

        for (int i = 0; i < quiz.GetLength(0); i++)
        {
            if (stuAns[i].Equals(quiz[i, 1], StringComparison.OrdinalIgnoreCase))
            {
                marks++;
            }
        }

        return marks;
    }

    void ShowFeedback(string[] stuAns)
    {
        Console.WriteLine("--- Detailed Feedback ---");

        for (int i = 0; i < quiz.GetLength(0); i++)
        {
            if (stuAns[i].Equals(quiz[i, 1], StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Question " + (i + 1) + ": Correct");
            }
            else
            {
                Console.WriteLine(
                    "Question " + (i + 1) +
                    ": Incorrect (Correct Answer: " + quiz[i, 1] + ")"
                );
            }
        }
    }

    //  RETURNS percentage so teacher can store it
    double ShowResult(int marks, int total)
    {
        double percentage = (marks * 100.0) / total;

        Console.WriteLine("--- Result ---");
        Console.WriteLine("Score: " + marks + "/" + total);
        Console.WriteLine("Percentage: " + percentage + "%");

        if (percentage >= 40)
            Console.WriteLine("Result: PASS");
        else
            Console.WriteLine("Result: FAIL");

        return percentage;
    }

    //  TEACHER MENU
    void TeacherMenu()
    {
        Console.WriteLine("Teacher View: Student Results ");

        if (studentCount == 0)
        {
            Console.WriteLine("No student has attempted the quiz yet.");
            return;
        }

        for (int i = 0; i < studentCount; i++)
        {
            Console.WriteLine(
                "Student " + (i + 1) +
                " | Marks: " + studentMarks[i] +
                " | Percentage: " + studentPercentages[i] + "%"
            );
        }
    }
}
