using HealthcareAnalytics.Core.Entities;
using HealthcareAnalytics.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;   

using Microsoft.AspNetCore.Mvc;

namespace HealthcareAnalytics.API.Controllers
{
    // API Controller for Appointment operations
    [Route("api/[controller]")]
    [ApiController]
    
    public class AppointmentsController : ControllerBase
    {
        // Service Layer object
        private readonly IAppointmentService _appointmentService;

        // Constructor Injection
        public AppointmentsController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        // =====================================================
        // GET: api/appointments
        // Get all appointments
        // =====================================================
        [HttpGet]
        public async Task<IActionResult> GetAllAppointments()
        {
            var appointments =
                await _appointmentService.GetAllAppointmentsAsync();

            return Ok(appointments);
        }

        // =====================================================
        // GET: api/appointments/{id}
        // Get appointment by ID
        // =====================================================
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppointmentById(int id)
        {
            var appointment =
                await _appointmentService.GetAppointmentByIdAsync(id);

            // Return 404 if appointment not found
            if (appointment == null)
            {
                return NotFound("Appointment not found.");
            }

            return Ok(appointment);
        }

        // =====================================================
        // POST: api/appointments
        // Create new appointment
        // =====================================================
        [HttpPost]
        public async Task<IActionResult> AddAppointment(
            Appointment appointment)
        {
            // Model validation
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _appointmentService.AddAppointmentAsync(appointment);

            return Ok("Appointment created successfully.");
        }

        // =====================================================
        // PUT: api/appointments/{id}
        // Update appointment
        // =====================================================
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAppointment(
            int id,
            Appointment appointment)
        {
            // Check ID mismatch
            if (id != appointment.AppointmentId)
            {
                return BadRequest("Appointment ID mismatch.");
            }

            await _appointmentService.UpdateAppointmentAsync(appointment);

            return Ok("Appointment updated successfully.");
        }

        // =====================================================
        // DELETE: api/appointments/{id}
        // Delete appointment
        // =====================================================
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            await _appointmentService.DeleteAppointmentAsync(id);

            return Ok("Appointment deleted successfully.");
        }
    }
}