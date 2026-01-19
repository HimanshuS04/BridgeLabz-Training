using System;
public class ExamMain
{
    static void Main()
    {
        ExamUtilityImpl utility = new ExamUtilityImpl();
        ExamMenu menu = new ExamMenu(utility);
        menu.ShowMenu();
    }
}