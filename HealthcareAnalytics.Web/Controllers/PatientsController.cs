using HealthcareAnalytics.Core.Entities;
using HealthcareAnalytics.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace HealthcareAnalytics.Web.Controllers
{
    // Controller handles all Patient related requests
    public class PatientsController : Controller
    {
        // Service object for business logic
        private readonly PatientService _patientService;

        // Constructor Injection
        // PatientService is injected automatically using Dependency Injection
        public PatientsController(PatientService patientService)
        {
            _patientService = patientService;
        }

        // ==========================================
        // DISPLAY ALL PATIENTS + SEARCH
        // URL: /Patients
        // ==========================================
        public async Task<IActionResult> Index(string searchString)
        {
            // Fetch all patients from database
            var patients = await _patientService.GetAllPatientsAsync();

            // Apply search filter
            if (!string.IsNullOrEmpty(searchString))
            {
                patients = patients
                    .Where(p => p.FullName.Contains(
                        searchString,
                        StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            // Send data to View
            return View(patients);
        }

        // ==========================================
        // OPEN CREATE PATIENT PAGE
        // URL: /Patients/Create
        // ==========================================
        public IActionResult Create()
        {
            return View();
        }

        // ==========================================
        // ADD NEW PATIENT
        // ==========================================
        [HttpPost]
        public async Task<IActionResult> Create(Patient patient)
        {
            // Check model validation
            if (ModelState.IsValid)
            {
                // Add patient using service layer
                await _patientService.AddPatientAsync(patient);

                // Redirect to Index page
                return RedirectToAction(nameof(Index));
            }

            // Return same page if validation fails
            return View(patient);
        }

        // ==========================================
        // OPEN EDIT PAGE
        // ==========================================
        public async Task<IActionResult> Edit(int id)
        {
            // Find patient by ID
            var patient = await _patientService.GetPatientByIdAsync(id);

            // If patient not found
            if (patient == null)
            {
                return NotFound();
            }

            // Send patient data to view
            return View(patient);
        }

        // ==========================================
        // UPDATE PATIENT
        // ==========================================
        [HttpPost]
        public async Task<IActionResult> Edit(Patient patient)
        {
            // Check validation
            if (ModelState.IsValid)
            {
                // Update patient
                await _patientService.UpdatePatientAsync(patient);

                // Redirect to Index page
                return RedirectToAction(nameof(Index));
            }

            return View(patient);
        }

        // ==========================================
        // OPEN DELETE CONFIRMATION PAGE
        // ==========================================
        public async Task<IActionResult> Delete(int id)
        {
            // Find patient by ID
            var patient = await _patientService.GetPatientByIdAsync(id);

            // Check if patient exists
            if (patient == null)
            {
                return NotFound();
            }

            // Send patient data to delete view
            return View(patient);
        }

        // ==========================================
        // DELETE PATIENT
        // ==========================================
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Delete patient from database
            await _patientService.DeletePatientAsync(id);

            // Redirect back to Index page
            return RedirectToAction(nameof(Index));
        }
    }
}