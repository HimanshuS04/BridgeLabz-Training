namespace HealthCare.Interfaces
{
    public interface IAdminServices
    {
        void AddSpecialization();
        void ViewSpecializations();
        void UpdateSpecialization();
        void DeleteSpecialization();
        void ViewAuditLogs();
        void ViewAuditByTable();
        void ViewAuditByOperation();
        void BackupDatabase();
        void RestoreDatabase();
    }
}
