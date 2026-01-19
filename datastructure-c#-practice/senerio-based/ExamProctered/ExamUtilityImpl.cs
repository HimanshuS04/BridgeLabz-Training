using System;

public class ExamUtilityImpl : IExamProctor
{
    private UniversalLinkedList questionStack = new UniversalLinkedList();
    private UniversalLinkedList answerMap = new UniversalLinkedList();

    private Question[] questions;
    private int currentIndex = 0;

    public ExamUtilityImpl()
    {
        LoadQuestions();
        questionStack.AddFirst(questions[0]);
    }

    private void LoadQuestions()
    {
        questions = new Question[]
        {
            new Question(1,"What is the output of: int x=5; Console.WriteLine(x++);","5",1),
            new Question(2,"Which keyword is used for inheritance in C#?"," :",1),
            new Question(3,"What does OOP stand for?","Object Oriented Programming",1),
            new Question(4,"Which data structure follows LIFO?","Stack",1),
            new Question(5,"What is default value of int in C#?","0",1),
            new Question(6,"Which loop runs at least once?","do-while",1),
            new Question(7,"Which keyword stops a loop?","break",1),
            new Question(8,"Which operator checks equality?","==",1),
            new Question(9,"What is method overloading?","Same method name different parameters",1),
            new Question(10,"Which collection does not allow duplicates?","Set",1)
        };
    }

    public void ShowCurrentQuestion()
    {
        Console.WriteLine(questions[currentIndex].ToString());
    }

    public void AnswerQuestion(string answer)
    {
        AnswerRecord record = new AnswerRecord(
            questions[currentIndex].GetQuestionId(), answer);

        answerMap.AddLast(record);

        if (currentIndex < questions.Length - 1)
        {
            currentIndex++;
            questionStack.AddFirst(questions[currentIndex]);
        }
    }

    public void GoBack()
    {
        questionStack.RemoveFirst();

        if (currentIndex > 0)
        {
            currentIndex--;
        }
    }

    public void SubmitExam()
    {
        int score = 0;
        UniversalLinkedList.Node node = answerMap.GetHead();

        while (node != null)
        {
            AnswerRecord ar = (AnswerRecord)node.GetData();

            for (int i = 0; i < questions.Length; i++)
            {
                if (questions[i].GetQuestionId() == ar.GetQuestionId())
                {
                    if (questions[i].GetCorrectAnswer()
                        .Equals(ar.GetStudentAnswer(), StringComparison.OrdinalIgnoreCase))
                    {
                        score += questions[i].GetMarks();
                    }
                }
            }
            node = node.GetNext();
        }

        Console.WriteLine("Final Score: " + score + "/" + questions.Length);
    }
}