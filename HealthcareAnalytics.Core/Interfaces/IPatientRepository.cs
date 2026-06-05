using HealthcareAnalytics.Core.Entities;

namespace HealthcareAnalytics.Core.Interfaces
{
    // Interface defines all database operations for Patient entity
    // This follows Dependency Inversion Principle (SOLID)
    public interface IPatientRepository
    {
        // Get all patients from database
        Task<IEnumerable<Patient>> GetAllPatientsAsync();

        // Get single patient by ID
        Task<Patient?> GetPatientByIdAsync(int id);

        // Add new patient
        Task AddPatientAsync(Patient patient);

        // Update existing patient
        Task UpdatePatientAsync(Patient patient);

        // Delete patient by ID
        Task DeletePatientAsync(int id);

        // Save changes to database
        Task SaveAsync();
    }
}