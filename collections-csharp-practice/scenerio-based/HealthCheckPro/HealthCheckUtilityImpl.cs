using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class HealthCheckUtilityImpl : IHealthCheck
{
    public void ScanApiMetadata()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine("\n🔍 API Metadata Scan Report");
        sb.AppendLine(new string('-', 35));

        var controllers = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.GetCustomAttribute<ApiControllerAttribute>() != null);

        foreach (var controller in controllers)
        {
            sb.AppendLine($"\n📌 Controller: {controller.Name}");

            var methods = controller.GetMethods(
                BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            foreach (var method in methods)
            {
                bool isPublicApi =
                    method.GetCustomAttribute<PublicAPIAttribute>() != null;

                bool isAuthApi =
                    method.GetCustomAttribute<RequiresAuthAttribute>() != null;

                // ONLY scan methods meant to be APIs
                if (!isPublicApi && !isAuthApi)
                    continue;

                string tag = isPublicApi ? "Public" : "Auth Required";
                sb.AppendLine($"   ✔ {method.Name,-20} [{tag}]");
            }
        }

        Console.WriteLine(sb.ToString());
    }

    public List<ApiMethodInfo> GenerateApiDocumentation()
    {
        List<ApiMethodInfo> docs = new List<ApiMethodInfo>();

        var controllers = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.GetCustomAttribute<ApiControllerAttribute>() != null);

        foreach (var controller in controllers)
        {
            var methods = controller.GetMethods(
                BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            foreach (var method in methods)
            {
                if (method.GetCustomAttribute<PublicAPIAttribute>() != null)
                {
                    docs.Add(new ApiMethodInfo
                    {
                        ControllerName = controller.Name,
                        MethodName = method.Name,
                        AccessType = "Public"
                    });
                }
                else if (method.GetCustomAttribute<RequiresAuthAttribute>() != null)
                {
                    docs.Add(new ApiMethodInfo
                    {
                        ControllerName = controller.Name,
                        MethodName = method.Name,
                        AccessType = "Auth Required"
                    });
                }
            }
        }

        return docs;
    }
}
