using HealthcareAnalytics.Data.Context;
using Microsoft.AspNetCore.Mvc;

namespace HealthcareAnalytics.Web.Controllers
{
    // Controller for analytics dashboard
    public class ReportsController : Controller
    {
        private readonly HealthcareDbContext _context;

        // Constructor
        public ReportsController(HealthcareDbContext context)
        {
            _context = context;
        }

        // Reports Dashboard
        public IActionResult Index()
        {
            // Total counts
            ViewBag.TotalPatients = _context.Patients.Count();

            ViewBag.TotalDoctors = _context.Doctors.Count();

            ViewBag.TotalAppointments = _context.Appointments.Count();

            return View();
        }
    }
}
