using HealthcareAnalytics.Core.DTOs;

namespace HealthcareAnalytics.Core.Interfaces
{
    // Interface for authentication business logic
    public interface IAuthService
    {
        // Register new user
        Task<string> RegisterAsync(RegisterRequestDto request);

        // Login user and return JWT token
        Task<string> LoginAsync(LoginRequestDto request);
    }
}
