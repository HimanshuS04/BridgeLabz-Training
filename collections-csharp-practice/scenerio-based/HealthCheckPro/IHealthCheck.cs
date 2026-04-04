using System.Collections.Generic;

public interface IHealthCheck
{
    void ScanApiMetadata();
    List<ApiMethodInfo> GenerateApiDocumentation();
}
