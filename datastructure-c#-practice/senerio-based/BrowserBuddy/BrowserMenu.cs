using System;

public class BrowserMenu
{
    private IBrowserOperations browser=new BrowserUtilityImpl();
    public void DisplayMenu()
    {
        int choice;
        do
        {
            Console.WriteLine("--- BrowserBuddy Menu ---");
            Console.WriteLine("1. Visit Page");
            Console.WriteLine("2. Back");
            Console.WriteLine("3. Forward");
            Console.WriteLine("4. Close Tab");
            Console.WriteLine("5. Restore Tab");
            Console.WriteLine("6. Show Current Page");
            Console.WriteLine("7. Exit");

            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    browser.VisitPage();
                    break;

                case 2:
                    browser.Back();
                    break;

                case 3:
                    browser.Forward();
                    break;

                case 4:
                    browser.CloseTab();
                    break;

                case 5:
                    browser.RestoreTab();
                    break;

                case 6:
                    browser.ShowCurrentPage();
                    break;
            }
        } while (choice != 7);
    }
}
