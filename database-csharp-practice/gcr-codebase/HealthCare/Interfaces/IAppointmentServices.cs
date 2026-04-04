namespace HealthCare.Interfaces
{
    public interface IAppointmentServices
    {
        void BookAppointment();        // UC-3.1
        void ViewAppointments();       // UC-3.2
        void CancelAppointment();      // UC-3.3
        void UpdateAppointmentStatus();// UC-3.4
    }
}
