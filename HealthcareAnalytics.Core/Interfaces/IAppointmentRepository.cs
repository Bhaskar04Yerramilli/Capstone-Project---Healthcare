using HealthcareAnalytics.Core.Entities;

namespace HealthcareAnalytics.Core.Interfaces
{
    // Interface for Appointment database operations
    public interface IAppointmentRepository
    {
        // Get all appointments
        Task<IEnumerable<Appointment>> GetAllAppointmentsAsync();

        // Get appointment by ID
        Task<Appointment?> GetAppointmentByIdAsync(int id);

        // Add new appointment
        Task AddAppointmentAsync(Appointment appointment);

        // Update appointment
        Task UpdateAppointmentAsync(Appointment appointment);

        // Delete appointment
        Task DeleteAppointmentAsync(int id);

        // Save changes to database
        Task SaveAsync();
    }
}
