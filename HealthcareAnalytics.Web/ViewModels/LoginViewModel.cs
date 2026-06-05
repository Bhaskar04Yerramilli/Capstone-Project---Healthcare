using System.ComponentModel.DataAnnotations;

namespace HealthcareAnalytics.Web.ViewModels
{
    // ViewModel for Login Page
    public class LoginViewModel
    {
        // User email
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        // User password
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}