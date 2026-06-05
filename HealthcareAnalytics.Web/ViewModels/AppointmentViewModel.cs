using System.ComponentModel.DataAnnotations;

namespace HealthcareAnalytics.Web.ViewModels
{
    // ViewModel for Appointment pages
    public class AppointmentViewModel
    {
        // Primary Key
        public int AppointmentId { get; set; }

        // Patient ID
        [Required]
        public int PatientId { get; set; }

        // Doctor ID
        [Required]
        public int DoctorId { get; set; }

        // Appointment Date
        [Required]
        public DateTime AppointmentDate { get; set; }

        // Appointment Status
        public string Status { get; set; } = "Scheduled";

        // Additional Notes
        public string Notes { get; set; } = string.Empty;
    }
}