using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;

public class EventTrackerUtilityImpl : IEventTracker
{
    public void ScanAuditEvents()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine("\n🔍 Audit Trail Scan Report");
        sb.AppendLine(new string('-', 35));

        var types = Assembly.GetExecutingAssembly().GetTypes();

        foreach (var type in types)
        {
            var methods = type.GetMethods(
                BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            var auditedMethods = methods
                .Select(m => new
                {
                    Method = m,
                    Audit = m.GetCustomAttribute<AuditTrailAttribute>()
                })
                .Where(x => x.Audit != null)
                .ToList();

            if (!auditedMethods.Any())
                continue;

            sb.AppendLine($"\n📌 Class: {type.Name}");

            foreach (var item in auditedMethods)
            {
                sb.AppendLine(
                    $"   ✔ {item.Method.Name,-20} Action: {item.Audit.ActionName}");
            }
        }

        Console.WriteLine(sb.ToString());
    }

    public string GenerateAuditJson()
    {
        List<AuditEventInfo> events = new List<AuditEventInfo>();

        var types = Assembly.GetExecutingAssembly().GetTypes();

        foreach (var type in types)
        {
            var methods = type.GetMethods(
                BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            foreach (var method in methods)
            {
                var audit = method.GetCustomAttribute<AuditTrailAttribute>();
                if (audit == null)
                    continue;

                events.Add(new AuditEventInfo
                {
                    ClassName = type.Name,
                    MethodName = method.Name,
                    Action = audit.ActionName,
                    Timestamp = DateTime.Now
                });
            }
        }

        return JsonSerializer.Serialize(events, new JsonSerializerOptions
        {
            WriteIndented = true
        });
    }
}
