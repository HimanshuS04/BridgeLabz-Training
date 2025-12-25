using System;

class EmployeeBonus
{
    // Generate salary and years of service for 10 employees
    public static int[,] GenerateEmployeeData(int employeeCount)
    {
        int[,] data = new int[employeeCount, 2]; // [0] = salary, [1] = years of service
        Random rand = new Random();

        for (int i = 0; i < employeeCount; i++)
        {
            data[i, 0] = rand.Next(10000, 100000); // 5-digit salary
            data[i, 1] = rand.Next(1, 11); // years of service 1 to 10
        }
        return data;
    }

    // Calculate new salary and bonus based on service years
    public static double[,] NewSalaryBonus(int[,] oldData)
    {
        int employeeCount = oldData.GetLength(0);
        double[,] newData = new double[employeeCount, 2]; // [0] = new salary, [1] = bonus
        for (int i = 0; i < employeeCount; i++)
        {
            double salary = oldData[i, 0];
            int years = oldData[i, 1];
            double bonus = (years > 5) ? salary * 0.05 : salary * 0.02;
            newData[i, 0] = salary + bonus;
            newData[i, 1] = bonus;
        }
        return newData;
    }

    // d. Calculate total old salary, new salary, and bonus
    public static void DisplaySummary(int[,] oldData, double[,] newData)
    {
        double totalOldSalary = 0;
        double totalNewSalary = 0;
        double totalBonus = 0;

        Console.WriteLine("\nEmployee Details:");
        Console.WriteLine("Emp\tOld Salary\tYears\tBonus\tNew Salary");

        for (int i = 0; i < oldData.GetLength(0); i++)
        {
            double oldSalary = oldData[i, 0];
            int years = oldData[i, 1];
            double bonus = newData[i, 1];
            double newSalary = newData[i, 0];

            totalOldSalary += oldSalary;
            totalNewSalary += newSalary;
            totalBonus += bonus;

            Console.WriteLine($"{i + 1}\t{oldSalary}\t\t{years}\t{bonus:F2}\t{newSalary:F2}");
        }

        Console.WriteLine("\nTotals:");
        Console.WriteLine($"Total Old Salary: {totalOldSalary:F2}");
        Console.WriteLine($"Total Bonus Amount: {totalBonus:F2}");
        Console.WriteLine($"Total New Salary: {totalNewSalary:F2}");
    }

    static void Main(string[] args)
    {
        int employeeCount = 10;

        // Generate random salary and years of service
        int[,] employeeData = GenerateEmployeeData(employeeCount);

        // Calculate new salary and bonus
        double[,] newSalaryData = NewSalaryBonus(employeeData);

        // Display summary in tabular format
        DisplaySummary(employeeData, newSalaryData);
    }
}
