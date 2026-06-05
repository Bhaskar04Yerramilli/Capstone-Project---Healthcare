using HealthcareAnalytics.Core.Entities;
using HealthcareAnalytics.Core.Interfaces;

namespace HealthcareAnalytics.Service.Services
{
    // Service layer handles business logic
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        // Constructor Injection
        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        // Get all patients
        public async Task<IEnumerable<Patient>> GetAllPatientsAsync()
        {
            return await _patientRepository.GetAllPatientsAsync();
        }

        // Get patient by ID
        public async Task<Patient?> GetPatientByIdAsync(int id)
        {
            return await _patientRepository.GetPatientByIdAsync(id);
        }

        // Add patient with business validation
        public async Task AddPatientAsync(Patient patient)
        {
            // Business Rule:
            // Patient age should not be future date
            if (patient.Age <= 0)
            {
                throw new Exception("Age must be greater than 0.");
            }

            await _patientRepository.AddPatientAsync(patient);

            await _patientRepository.SaveAsync();
        }

        // Update patient
        public async Task UpdatePatientAsync(Patient patient)
        {
            await _patientRepository.UpdatePatientAsync(patient);

            await _patientRepository.SaveAsync();
        }

        // Delete patient
        public async Task DeletePatientAsync(int id)
        {
            await _patientRepository.DeletePatientAsync(id);

            await _patientRepository.SaveAsync();
        }
    }
}