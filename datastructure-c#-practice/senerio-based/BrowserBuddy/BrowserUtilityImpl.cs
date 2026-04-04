using System;
using System.Collections.Generic;

public class BrowserUtilityImpl : IBrowserOperations
{
    private GlobalLinkedList history= new GlobalLinkedList();
    private GlobalLinkedList.Node current=null;
    private Stack<GlobalLinkedList> closedTabs= new Stack<GlobalLinkedList>();
     public void VisitPage()
    {
        Console.WriteLine("Enter url");
        string url= Console.ReadLine();
        BrowserPage page = new BrowserPage();
        page.SetUrl(url);

        // Clear forward history
        if (current != null && current.GetNext() != null)
        {
            current.SetNext(null);
        }

        history.AddLast(page);

        if (current == null)
            current = history.GetHead();
        else
            current = current.GetNext();

        Console.WriteLine("Visited: " + page);
    }

    public void Back()
    {
        if (current != null && current.GetPrev() != null)
        {
            current = current.GetPrev();
            Console.WriteLine("Back to: " + current.GetData());
        }
        else
        {
            Console.WriteLine("No previous page.");
        }
    }

    public void Forward()
    {
        if (current != null && current.GetNext() != null)
        {
            current = current.GetNext();
            Console.WriteLine("Forward to: " + current.GetData());
        }
        else
        {
            Console.WriteLine("No forward page.");
        }
    }

    public void CloseTab()
    {
        closedTabs.Push(history);
        history = new GlobalLinkedList();
        current = null;
        Console.WriteLine("Tab closed.");
    }

    public void RestoreTab()
    {
        if (closedTabs.Count > 0)
        {
            history = closedTabs.Pop();
            current = history.GetHead();
            Console.WriteLine("Tab restored.");
        }
        else
        {
            Console.WriteLine("No tabs to restore.");
        }
    }

    public void ShowCurrentPage()
    {
        if (current != null)
            Console.WriteLine("Current Page: " + current.GetData());
        else
            Console.WriteLine("No page opened.");
    }
}
