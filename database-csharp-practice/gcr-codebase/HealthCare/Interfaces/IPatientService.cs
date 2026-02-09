namespace HealthCare.Interfaces
{
    public interface IPatientService
    {
        void RegisterPatient();      // UC-1.1
        void UpdatePatient();        // UC-1.2
        void SearchPatient();        // UC-1.3
        void ViewVisitHistory();     // UC-1.4
    }
}
