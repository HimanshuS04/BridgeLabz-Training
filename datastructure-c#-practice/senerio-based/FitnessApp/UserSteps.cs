using System;
public class UserSteps
{
    private string name;
    private int steps;

    public UserSteps(string name, int steps)
    {
        this.name = name;
        this.steps = steps;
    }

    public string GetName()
    {
        return name;
    }

    public void SetName(string name)
    {
        this.name = name;
    }

    public int GetSteps()
    {
        return steps;
    }

    public void SetSteps(int steps)
    {
        this.steps = steps;
    }

    public override string ToString()
    {
        return "Name: " + name + " | Steps: " + steps;
    }
}
