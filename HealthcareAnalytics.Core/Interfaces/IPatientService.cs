using HealthcareAnalytics.Core.Entities;

namespace HealthcareAnalytics.Core.Interfaces
{
    // Service interface contains business logic methods
    public interface IPatientService
    {
        // Get all patients
        Task<IEnumerable<Patient>> GetAllPatientsAsync();

        // Get patient by ID
        Task<Patient?> GetPatientByIdAsync(int id);

        // Add new patient
        Task AddPatientAsync(Patient patient);

        // Update existing patient
        Task UpdatePatientAsync(Patient patient);

        // Delete patient
        Task DeletePatientAsync(int id);
    }
}