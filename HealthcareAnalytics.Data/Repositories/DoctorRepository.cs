using HealthcareAnalytics.Core.Entities;
using HealthcareAnalytics.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace HealthcareAnalytics.Data.Repositories
{
    // Repository for Doctor CRUD operations
    public class DoctorRepository
    {
        private readonly HealthcareDbContext _context;

        // Constructor
        public DoctorRepository(HealthcareDbContext context)
        {
            _context = context;
        }

        // Get all doctors
        public async Task<List<Doctor>> GetAllDoctorsAsync()
        {
            return await _context.Doctors.ToListAsync();
        }

        // Get doctor by ID
        public async Task<Doctor?> GetDoctorByIdAsync(int id)
        {
            return await _context.Doctors.FindAsync(id);
        }

        // Add new doctor
        public async Task AddDoctorAsync(Doctor doctor)
        {
            _context.Doctors.Add(doctor);

            await _context.SaveChangesAsync();
        }

        // Update doctor
        public async Task UpdateDoctorAsync(Doctor doctor)
        {
            _context.Doctors.Update(doctor);

            await _context.SaveChangesAsync();
        }

        // Delete doctor
        public async Task DeleteDoctorAsync(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);

            if (doctor != null)
            {
                _context.Doctors.Remove(doctor);

                await _context.SaveChangesAsync();
            }
        }
    }
}