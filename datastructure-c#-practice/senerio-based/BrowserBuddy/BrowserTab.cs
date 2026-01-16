public class BrowserTab
{
    private GlobalLinkedList History= new GlobalLinkedList();
    private GlobalLinkedList.Node current=null;
    public GlobalLinkedList GetHistory()
    {
        return History;
    }

    public void SetHistory(GlobalLinkedList History)
    {
        this.History = History;
    }

    public GlobalLinkedList.Node GetCurrent()
    {
        return current;
    }

    public void SetCurrent(GlobalLinkedList.Node current)
    {
        this.current = current;
    }
}
