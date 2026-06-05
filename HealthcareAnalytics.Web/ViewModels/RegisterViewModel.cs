using System.ComponentModel.DataAnnotations;

namespace HealthcareAnalytics.Web.ViewModels
{
    // ViewModel for Registration Page
    public class RegisterViewModel
    {
        // Full Name
        [Required]
        public string FullName { get; set; } = string.Empty;

        // Email
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        // Password
        [Required]
        public string Password { get; set; } = string.Empty;

        // Role
        [Required]
        public string Role { get; set; } = string.Empty;
    }
}