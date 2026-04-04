using System;
public class StepUtilityImpl : IStepService
{
    private UserSteps[] users;
    private int count;

    public StepUtilityImpl()
    {
        users = new UserSteps[20];
        count = 0;

        users[count++] = new UserSteps("Amit", 6500);
        users[count++] = new UserSteps("Riya", 8200);
        users[count++] = new UserSteps("Karan", 7400);
        users[count++] = new UserSteps("Sneha", 9000);
        users[count++] = new UserSteps("Vikram", 5000);
    }

    public void AddUser(string name, int steps)
    {
        if (count >= 20)
        {
            Console.WriteLine("User limit reached");
            return;
        }

        users[count++] = new UserSteps(name, steps);
    }

    public void UpdateSteps(int index, int steps)
    {
        if (index < 0 || index >= count)
        {
            Console.WriteLine("Invalid index");
            return;
        }

        users[index].SetSteps(steps);
    }

    public void ShowLeaderboard()
    {
        BubbleSort();

        Console.WriteLine("\n--- Fitness Leaderboard ---");
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine((i + 1) + ". " + users[i]);
        }
    }

    private void BubbleSort()
    {
        for (int i = 0; i < count - 1; i++)
        {
            for (int j = 0; j < count - i - 1; j++)
            {
                if (users[j].GetSteps() < users[j + 1].GetSteps())
                {
                    UserSteps temp = users[j];
                    users[j] = users[j + 1];
                    users[j + 1] = temp;
                }
            }
        }
    }
}
