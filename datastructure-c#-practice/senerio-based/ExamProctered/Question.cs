using System;
public class Question
{
    private int questionId;
    private string questionText;
    private string correctAnswer;
    private int marks;

    public Question(int questionId, string questionText, string correctAnswer, int marks)
    {
        this.questionId = questionId;
        this.questionText = questionText;
        this.correctAnswer = correctAnswer;
        this.marks = marks;
    }

    public int GetQuestionId()
    {
        return questionId;
    }

    public void SetQuestionId(int questionId)
    {
        this.questionId = questionId;
    }

    public string GetQuestionText()
    {
        return questionText;
    }

    public void SetQuestionText(string questionText)
    {
        this.questionText = questionText;
    }

    public string GetCorrectAnswer()
    {
        return correctAnswer;
    }

    public void SetCorrectAnswer(string correctAnswer)
    {
        this.correctAnswer = correctAnswer;
    }

    public int GetMarks()
    {
        return marks;
    }

    public void SetMarks(int marks)
    {
        this.marks = marks;
    }

    public override string ToString()
    {
        return questionId + ". " + questionText;
    }
}