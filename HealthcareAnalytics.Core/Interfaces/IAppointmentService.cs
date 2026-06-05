using HealthcareAnalytics.Core.Entities;

namespace HealthcareAnalytics.Core.Interfaces
{
    // Service interface for Appointment business logic
    public interface IAppointmentService
    {
        Task<IEnumerable<Appointment>> GetAllAppointmentsAsync();

        Task<Appointment?> GetAppointmentByIdAsync(int id);

        Task AddAppointmentAsync(Appointment appointment);

        Task UpdateAppointmentAsync(Appointment appointment);

        Task DeleteAppointmentAsync(int id);
    }
}