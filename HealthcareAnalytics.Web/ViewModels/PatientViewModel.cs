using System.ComponentModel.DataAnnotations;

namespace HealthcareAnalytics.Web.ViewModels
{
    // ViewModel for Patient UI
    public class PatientViewModel
    {
        // Patient ID
        public int PatientId { get; set; }

        // Full Name
        [Required]
        public string FullName { get; set; } = string.Empty;

        // Age
        [Range(1, 120)]
        public int Age { get; set; }

        // Gender
        [Required]
        public string Gender { get; set; } = string.Empty;

        // Phone Number
        [Required]
        public string Phone { get; set; } = string.Empty;

        // Address
        [Required]
        public string Address { get; set; } = string.Empty;
    }
}