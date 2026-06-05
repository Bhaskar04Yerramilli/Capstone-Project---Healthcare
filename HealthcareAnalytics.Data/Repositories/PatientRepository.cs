using HealthcareAnalytics.Core.Entities;
using HealthcareAnalytics.Core.Interfaces;
using HealthcareAnalytics.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace HealthcareAnalytics.Data.Repositories
{
    // Repository class handles Patient database operations
    public class PatientRepository : IPatientRepository
    {
        // DbContext object for database communication
        private readonly HealthcareDbContext _context;

        // Constructor Injection
        public PatientRepository(HealthcareDbContext context)
        {
            _context = context;
        }

        // Get all patients
        public async Task<IEnumerable<Patient>> GetAllPatientsAsync()
        {
            return await _context.Patients.ToListAsync();
        }

        // Get patient by ID
        public async Task<Patient?> GetPatientByIdAsync(int id)
        {
            return await _context.Patients.FindAsync(id);
        }

        // Add new patient
        public async Task AddPatientAsync(Patient patient)
        {
            await _context.Patients.AddAsync(patient);
        }

        // Update patient
        public async Task UpdatePatientAsync(Patient patient)
        {
            _context.Patients.Update(patient);

            await Task.CompletedTask;
        }

        // Delete patient
        public async Task DeletePatientAsync(int id)
        {
            var patient = await _context.Patients.FindAsync(id);

            if (patient != null)
            {
                _context.Patients.Remove(patient);
            }
        }

        // Save changes to database
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}