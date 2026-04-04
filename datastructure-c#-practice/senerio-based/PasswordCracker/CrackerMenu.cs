using System;

public class CrackerMenu
{
    private CrackerUtilityImpl utility = new CrackerUtilityImpl();


    public void ShowMenu()
    {
        while (true)
        {
            Console.WriteLine("1. Crack user given password");
            Console.WriteLine("2. Generate random password and crack");
            Console.WriteLine("3. Exit");
            Console.Write("Enter Choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter password (use a,b,c,1,2 only): ");
                    string userPwd = Console.ReadLine();
                    utility.CrackUserPassword(userPwd);
                    break;

                case 2:
                    Console.Write("Enter password length: ");
                    int len = int.Parse(Console.ReadLine());
                    utility.CrackRandomPassword(len);
                    break;

                case 3:
                    return;
            }
        }
    }
}
