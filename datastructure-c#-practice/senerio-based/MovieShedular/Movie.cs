using System;
class Movie
{
    private string Title;
    private string Time;

    public void SetTitle(string Title)
    {
        this.Title=Title;
    }
    public string GetTitle()
    {
        return Title;
    }
    public void SetTime(string Time)
    {
        this.Time=Time;
    }
    public string GetTime()
    {
        return Time;
    }
    public override string ToString()
    {
        return $"Title : {Title} | Time : {Time}";
    }
}