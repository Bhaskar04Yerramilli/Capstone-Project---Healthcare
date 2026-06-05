using System.ComponentModel.DataAnnotations;

namespace HealthcareAnalytics.Core.DTOs
{
    // DTO for user registration
    public class RegisterRequestDto
    {
        // Full name of user
        [Required]
        public string FullName { get; set; } = string.Empty;

        // Email for login
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        // Password
        [Required]
        public string Password { get; set; } = string.Empty;

        // User role
        // Example: Admin or Doctor
        [Required]
        public string Role { get; set; } = string.Empty;
    }
}
