using HealthcareAnalytics.Core.Entities;
using HealthcareAnalytics.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HealthcareAnalytics.Web.Controllers
{
    // Controller for Doctor module
    public class DoctorsController : Controller
    {
        private readonly DoctorRepository _doctorRepository;

        // Constructor
        public DoctorsController(DoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        // ==============================
        // Display all doctors + Search
        // ==============================
        public async Task<IActionResult> Index(string searchString)
        {
            // Fetch all doctors
            var doctors = await _doctorRepository.GetAllDoctorsAsync();

            // Apply search filter
            if (!string.IsNullOrEmpty(searchString))
            {
                doctors = doctors
                    .Where(d =>
                        d.Name.Contains(searchString,
                        StringComparison.OrdinalIgnoreCase)

                        ||

                        d.Specialization.Contains(searchString,
                        StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            return View(doctors);
        }

        // ==============================
        // Show Create Page
        // ==============================
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // ==============================
        // Save New Doctor
        // ==============================
        [HttpPost]
        public async Task<IActionResult> Create(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                await _doctorRepository.AddDoctorAsync(doctor);

                return RedirectToAction("Index");
            }

            return View(doctor);
        }

        // ==============================
        // Show Edit Page
        // ==============================
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var doctor = await _doctorRepository.GetDoctorByIdAsync(id);

            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // ==============================
        // Update Doctor
        // ==============================
        [HttpPost]
        public async Task<IActionResult> Edit(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                await _doctorRepository.UpdateDoctorAsync(doctor);

                return RedirectToAction("Index");
            }

            return View(doctor);
        }

        // ==============================
        // Show Delete Page
        // ==============================
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var doctor = await _doctorRepository.GetDoctorByIdAsync(id);

            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // ==============================
        // Confirm Delete
        // ==============================
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _doctorRepository.DeleteDoctorAsync(id);

            return RedirectToAction("Index");
        }
    }
}