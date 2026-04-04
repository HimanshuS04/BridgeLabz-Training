using System;
interface IStepService
{
    void AddUser(string name, int steps);
    void UpdateSteps(int index, int steps);
    void ShowLeaderboard();
}
