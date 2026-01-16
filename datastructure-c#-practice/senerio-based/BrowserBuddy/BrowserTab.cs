public class BrowserPage
{
    private string url;

    public void SetUrl(string url)
    {
        this.url = url;
    }

    public string GetUrl()
    {
        return url;
    }

    public override string ToString()
    {
        return url;
    }
}
