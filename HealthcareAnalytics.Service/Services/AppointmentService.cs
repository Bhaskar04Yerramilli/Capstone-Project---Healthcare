using HealthcareAnalytics.Core.Entities;
using HealthcareAnalytics.Core.Interfaces;

namespace HealthcareAnalytics.Service.Services
{
    // Service layer handles Appointment business logic
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        // Constructor Injection
        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        // Get all appointments
        public async Task<IEnumerable<Appointment>> GetAllAppointmentsAsync()
        {
            return await _appointmentRepository.GetAllAppointmentsAsync();
        }

        // Get appointment by ID
        public async Task<Appointment?> GetAppointmentByIdAsync(int id)
        {
            return await _appointmentRepository.GetAppointmentByIdAsync(id);
        }

        // Add new appointment with business validation
        public async Task AddAppointmentAsync(Appointment appointment)
        {
            // Business Rule:
            // Appointment date cannot be in the past
            if (appointment.AppointmentDate < DateTime.Now)
            {
                throw new Exception("Appointment date cannot be in the past.");
            }

            await _appointmentRepository.AddAppointmentAsync(appointment);

            await _appointmentRepository.SaveAsync();
        }

        // Update appointment
        public async Task UpdateAppointmentAsync(Appointment appointment)
        {
            await _appointmentRepository.UpdateAppointmentAsync(appointment);

            await _appointmentRepository.SaveAsync();
        }

        // Delete appointment
        public async Task DeleteAppointmentAsync(int id)
        {
            await _appointmentRepository.DeleteAppointmentAsync(id);

            await _appointmentRepository.SaveAsync();
        }
    }
}