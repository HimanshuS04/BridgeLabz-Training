using System;

public class AadharMenu
{
    private AadharUtilityImpl utility= new AadharUtilityImpl();

    public void ShowMenu()
    {
        while (true)
        {
            Console.WriteLine("1. Display All Aadhar Records");
            Console.WriteLine("2. Sort Aadhar Records ");
            Console.WriteLine("3. Search Aadhar Record");
            Console.WriteLine("4. Exit");

            Console.Write("Enter choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    utility.DisplayAll();
                    break;

                case 2:
                    utility.SortAadhar();
                    break;

                case 3:
                    utility.SearchAadhar();
                    break;

                case 4:
                    return;
            }
        }
    }
}
