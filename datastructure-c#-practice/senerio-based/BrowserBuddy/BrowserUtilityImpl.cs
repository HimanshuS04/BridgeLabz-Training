using System;

public class BrowserUtilityImpl : IBrowserOperations
{
    private BrowserTab currentTab=new BrowserTab();
    private Stack<BrowserTab> closedTabs=new Stack<BrowserTab>();
    public void VisitPage()
    {
        Console.WriteLine("Enter the url");
        string url=Console.ReadLine();
        GlobalLinkedList history = currentTab.GetHistory();
        GlobalLinkedList.Node current = currentTab.GetCurrent();

        // Remove forward history if exists
        if (current != null && current.GetNext() != null)
        {
            current.SetNext(null);
        }

        history.AddLast(url);

        if (current == null)
            currentTab.SetCurrent(history.GetHead());
        else
            currentTab.SetCurrent(current.GetNext());

        Console.WriteLine("Visited: " + url);
    }

    public void Back()
    {
        GlobalLinkedList.Node current = currentTab.GetCurrent();

        if (current != null && current.GetPrev() != null)
        {
            currentTab.SetCurrent(current.GetPrev());
            Console.WriteLine("Back to: " + currentTab.GetCurrent().GetData());
        }
        else
        {
            Console.WriteLine("No previous page.");
        }
    }

    public void Forward()
    {
        GlobalLinkedList.Node current = currentTab.GetCurrent();

        if (current != null && current.GetNext() != null)
        {
            currentTab.SetCurrent(current.GetNext());
            Console.WriteLine("Forward to: " + currentTab.GetCurrent().GetData());
        }
        else
        {
            Console.WriteLine("No forward page.");
        }
    }

    public void CloseTab()
    {
        closedTabs.Push(currentTab);
        currentTab = new BrowserTab();
        Console.WriteLine("Tab closed.");
    }

    public void RestoreTab()
    {
        if (closedTabs.Count > 0)
        {
            currentTab = closedTabs.Pop();
            Console.WriteLine("Tab restored.");
        }
        else
        {
            Console.WriteLine("No closed tabs to restore.");
        }
    }

    public void ShowCurrentPage()
    {
        if (currentTab.GetCurrent() != null)
            Console.WriteLine("Current Page: " + currentTab.GetCurrent().GetData());
        else
            Console.WriteLine("No page opened.");
    }
}
