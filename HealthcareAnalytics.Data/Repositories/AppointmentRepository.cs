using HealthcareAnalytics.Core.Entities;
using HealthcareAnalytics.Core.Interfaces;
using HealthcareAnalytics.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace HealthcareAnalytics.Data.Repositories
{
    // Repository class handles Appointment database operations
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly HealthcareDbContext _context;

        // Constructor Injection
        public AppointmentRepository(HealthcareDbContext context)
        {
            _context = context;
        }

        // Get all appointments
        public async Task<IEnumerable<Appointment>> GetAllAppointmentsAsync()
        {
            return await _context.Appointments.ToListAsync();
        }

        // Get appointment by ID
        public async Task<Appointment?> GetAppointmentByIdAsync(int id)
        {
            return await _context.Appointments.FindAsync(id);
        }

        // Add new appointment
        public async Task AddAppointmentAsync(Appointment appointment)
        {
            await _context.Appointments.AddAsync(appointment);
        }

        // Update appointment
        public async Task UpdateAppointmentAsync(Appointment appointment)
        {
            _context.Appointments.Update(appointment);

            await Task.CompletedTask;
        }

        // Delete appointment
        public async Task DeleteAppointmentAsync(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);

            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
            }
        }

        // Save changes to database
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}