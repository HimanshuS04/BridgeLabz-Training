using System;
class Movie
{
    private string title;
    private string time;

    public void SetTitle(string title)
    {
        this.title=title;
    }
    public string GetTitle()
    {
        return title;
    }
    public void SetTime(string time)
    {
        this.time=time;
    }
    public string GetTime()
    {
        return time;
    }
    public override string ToString()
    {
        return $"Title : {title} | Time : {time}";
    }
}