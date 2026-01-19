using System;
public class AnswerRecord
{
    private int questionId;
    private string studentAnswer;

    public AnswerRecord(int questionId, string studentAnswer)
    {
        this.questionId = questionId;
        this.studentAnswer = studentAnswer;
    }

    public int GetQuestionId()
    {
        return questionId;
    }

    public void SetQuestionId(int questionId)
    {
        this.questionId = questionId;
    }

    public string GetStudentAnswer()
    {
        return studentAnswer;
    }

    public void SetStudentAnswer(string studentAnswer)
    {
        this.studentAnswer = studentAnswer;
    }

    public override string ToString()
    {
        return "QID: " + questionId + ", Answer: " + studentAnswer;
    }
}