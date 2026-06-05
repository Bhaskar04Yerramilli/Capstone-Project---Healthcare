using System.ComponentModel.DataAnnotations;

namespace HealthcareAnalytics.Core.Entities
{
    // Represents patient details in the healthcare system
    public class Patient
    {
        // Primary Key
        public int PatientId { get; set; }

        // Patient full name
        [Required]
        [StringLength(100)]
        public string FullName { get; set; } = string.Empty;

        // Gender of patient
        [Required]
        public string Gender { get; set; } = string.Empty;

        // Patient age
        public int Age { get; set; }

        // Phone number validation
        [Phone]
        public string Phone { get; set; } = string.Empty;

        // Patient address
        public string Address { get; set; } = string.Empty;

        

        // Navigation Property
        // One Patient can have many appointments
        public ICollection<Appointment>? Appointments { get; set; }
    }
}