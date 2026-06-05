using HealthcareAnalytics.Core.Entities;
using HealthcareAnalytics.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthcareAnalytics.API.Controllers
{
    // API Controller
    [Route("api/[controller]")]
    [ApiController]

    // Secure controller using JWT Authentication
    

    public class PatientsController : ControllerBase
    {
        // Dependency Injection of Service Layer
        private readonly IPatientService _patientService;

        // Constructor
        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        // =====================================================
        // GET ALL PATIENTS
        // =====================================================
        [HttpGet]
        public async Task<IActionResult> GetPatients()
        {
            // Fetch all patients from service
            var patients =
                await _patientService.GetAllPatientsAsync();

            // Return patient list
            return Ok(patients);
        }

        // =====================================================
        // GET PATIENT BY ID
        // =====================================================
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientById(int id)
        {
            // Fetch patient by ID
            var patient =
                await _patientService.GetPatientByIdAsync(id);

            // If patient not found
            if (patient == null)
            {
                return NotFound();
            }

            // Return patient
            return Ok(patient);
        }

        // =====================================================
        // CREATE PATIENT
        // =====================================================
        [HttpPost]
        public async Task<IActionResult> AddPatient(
            [FromBody] Patient patient)
        {
            // Add patient using service layer
            await _patientService.AddPatientAsync(patient);

            // Return success response
            return Ok(patient);
        }

        // =====================================================
        // UPDATE PATIENT
        // =====================================================
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatient(
            int id,
            [FromBody] Patient patient)
        {
            // Validate ID
            if (id != patient.PatientId)
            {
                return BadRequest();
            }

            // Update patient
            await _patientService.UpdatePatientAsync(patient);

            // Return updated patient
            return Ok(patient);
        }

        // =====================================================
        // DELETE PATIENT
        // =====================================================
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            // Delete patient
            await _patientService.DeletePatientAsync(id);

            // Return success
            return Ok();
        }
    }
}