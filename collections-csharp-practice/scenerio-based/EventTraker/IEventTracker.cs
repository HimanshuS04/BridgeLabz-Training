using System.Collections.Generic;

public interface IEventTracker
{
    void ScanAuditEvents();
    string GenerateAuditJson();
}
