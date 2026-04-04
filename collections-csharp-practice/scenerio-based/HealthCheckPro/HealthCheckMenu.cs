using System;
using System.Collections.Generic;

public class HealthCheckMenu
{
    private IHealthCheck healthCheck = new HealthCheckUtilityImpl();

    public void ShowMenu()
    {
        while (true)
        {
            Console.WriteLine("\n1. Scan API Metadata");
            Console.WriteLine("2. Generate API Documentation");
            Console.WriteLine("3. Exit");
            Console.Write("Enter choice: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    healthCheck.ScanApiMetadata();
                    break;

                case 2:
                    List<ApiMethodInfo> docs = healthCheck.GenerateApiDocumentation();
                    DisplayDocs(docs);
                    break;

                case 3:
                    return;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }

    private void DisplayDocs(List<ApiMethodInfo> docs)
    {
        Console.WriteLine("\n📘 API Documentation");
        foreach (var doc in docs)
        {
            Console.WriteLine(
                $"{doc.ControllerName} -> {doc.MethodName} [{doc.AccessType}]");
        }
    }
}
