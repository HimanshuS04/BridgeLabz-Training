using System;

public class ExamMenu
{
    private ExamUtilityImpl utility= new ExamUtilityImpl();
    public void ShowMenu()
    {
        while (true)
        {
            Console.WriteLine("1. Show Question");
            Console.WriteLine("2. Answer Question");
            Console.WriteLine("3. Go Back");
            Console.WriteLine("4. Submit Exam");
            Console.WriteLine("5. Exit");
            Console.Write("Choice : ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    utility.ShowCurrentQuestion();
                    break;

                case 2:
                    Console.Write("Enter Answer: ");
                    utility.AnswerQuestion(Console.ReadLine());
                    break;

                case 3:
                    utility.GoBack();
                    break;

                case 4:
                    utility.SubmitExam();
                    return;

                case 5:
                    return;
            }
        }
    }
}