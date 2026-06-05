using System.ComponentModel.DataAnnotations;

namespace HealthcareAnalytics.Core.Entities
{
    // Represents appointment booking details
    public class Appointment
    {
        // Primary Key
        public int AppointmentId { get; set; }

        // Foreign Key referencing Patient table
        [Required]
        public int PatientId { get; set; }

        // Foreign Key referencing Doctor table
        [Required]
        public int DoctorId { get; set; }

        // Appointment date and time
        [Required]
        public DateTime AppointmentDate { get; set; }

        // Appointment status
        // Default value = Scheduled
        public string Status { get; set; } = "Scheduled";

        // Additional notes
        public string Notes { get; set; } = string.Empty;

        // Navigation Property for Patient
        public Patient? Patient { get; set; }

        // Navigation Property for Doctor
        public Doctor? Doctor { get; set; }
    }
}