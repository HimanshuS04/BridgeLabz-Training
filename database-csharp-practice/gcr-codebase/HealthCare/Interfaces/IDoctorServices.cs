namespace HealthCare.Interfaces
{
    public interface IDoctorServices
    {
        void AddDoctor();                 // UC-2.1
        void UpdateDoctor();              // UC-2.2
        void ViewDoctorsBySpecialty();    // UC-2.3
        void DeactivateDoctor();          // UC-2.4
    }
}
