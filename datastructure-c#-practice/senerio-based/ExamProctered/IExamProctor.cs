using System;

public interface IExamProctor
{
    void ShowCurrentQuestion();
    void AnswerQuestion(string answer);
    void GoBack();
    void SubmitExam();
}