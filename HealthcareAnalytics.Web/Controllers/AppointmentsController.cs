using HealthcareAnalytics.Core.Entities;
using HealthcareAnalytics.Service.Services;
using HealthcareAnalytics.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HealthcareAnalytics.Web.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly AppointmentService _appointmentService;

        public AppointmentsController(AppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        // ==========================================
        // DISPLAY APPOINTMENTS + SEARCH
        // ==========================================
        public async Task<IActionResult> Index(string searchString)
        {
            // Fetch appointments
            var appointments = await _appointmentService.GetAllAppointmentsAsync();

            // Apply search filter
            if (!string.IsNullOrEmpty(searchString))
            {
                appointments = appointments
                    .Where(a =>
                        a.Status.Contains(searchString,
                        StringComparison.OrdinalIgnoreCase)

                        ||

                        a.PatientId.ToString().Contains(searchString)

                        ||

                        a.DoctorId.ToString().Contains(searchString))
                    .ToList();
            }

            // Convert to ViewModel
            var viewModels = appointments.Select(a => new AppointmentViewModel
            {
                AppointmentId = a.AppointmentId,
                PatientId = a.PatientId,
                DoctorId = a.DoctorId,
                AppointmentDate = a.AppointmentDate,
                Status = a.Status,
                Notes = a.Notes
            }).ToList();

            return View(viewModels);
        }

        // ==========================================
        // CREATE PAGE
        // ==========================================
        public IActionResult Create()
        {
            return View();
        }

        // ==========================================
        // SAVE APPOINTMENT
        // ==========================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AppointmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var appointment = new Appointment
                {
                    PatientId = model.PatientId,
                    DoctorId = model.DoctorId,
                    AppointmentDate = model.AppointmentDate,
                    Status = model.Status,
                    Notes = model.Notes
                };

                await _appointmentService.AddAppointmentAsync(appointment);

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // ==========================================
        // EDIT PAGE
        // ==========================================
        public async Task<IActionResult> Edit(int id)
        {
            var appointment = await _appointmentService.GetAppointmentByIdAsync(id);

            if (appointment == null)
            {
                return NotFound();
            }

            var viewModel = new AppointmentViewModel
            {
                AppointmentId = appointment.AppointmentId,
                PatientId = appointment.PatientId,
                DoctorId = appointment.DoctorId,
                AppointmentDate = appointment.AppointmentDate,
                Status = appointment.Status,
                Notes = appointment.Notes
            };

            return View(viewModel);
        }

        // ==========================================
        // UPDATE APPOINTMENT
        // ==========================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AppointmentViewModel model)
        {
            if (id != model.AppointmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var appointment = new Appointment
                {
                    AppointmentId = model.AppointmentId,
                    PatientId = model.PatientId,
                    DoctorId = model.DoctorId,
                    AppointmentDate = model.AppointmentDate,
                    Status = model.Status,
                    Notes = model.Notes
                };

                await _appointmentService.UpdateAppointmentAsync(appointment);

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // ==========================================
        // DELETE APPOINTMENT
        // ==========================================
        public async Task<IActionResult> Delete(int id)
        {
            var appointment = await _appointmentService.GetAppointmentByIdAsync(id);

            if (appointment == null)
            {
                return NotFound();
            }

            await _appointmentService.DeleteAppointmentAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}