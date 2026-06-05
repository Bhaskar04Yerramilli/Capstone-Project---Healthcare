using HealthcareAnalytics.Core.DTOs;
using HealthcareAnalytics.Core.Entities;
using HealthcareAnalytics.Core.Interfaces;

using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HealthcareAnalytics.Service.Services
{
    // Service handles authentication business logic
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;

        private readonly IConfiguration _configuration;

        // Constructor Injection
        public AuthService(
            IAuthRepository authRepository,
            IConfiguration configuration)
        {
            _authRepository = authRepository;
            _configuration = configuration;
        }

        // =====================================================
        // Register new user
        // =====================================================
        public async Task<string> RegisterAsync(
            RegisterRequestDto request)
        {
            // Check if email already exists
            var existingUser =
                await _authRepository.GetUserByEmailAsync(request.Email);

            if (existingUser != null)
            {
                throw new Exception("Email already registered.");
            }

            // Create new user object
            var user = new User
            {
                FullName = request.FullName,
                Email = request.Email,

                // NOTE:
                // For demo project only.
                // In real projects passwords must be hashed.
                PasswordHash = request.Password,

                Role = request.Role
            };

            // Save user
            await _authRepository.RegisterUserAsync(user);

            await _authRepository.SaveAsync();

            return "User registered successfully.";
        }

        // =====================================================
        // Login user
        // =====================================================
        public async Task<string> LoginAsync(
            LoginRequestDto request)
        {
            // Find user by email
            var user =
                await _authRepository.GetUserByEmailAsync(request.Email);

            // Validate user
            if (user == null ||
                user.PasswordHash != request.Password)
            {
                throw new Exception("Invalid email or password.");
            }

            // Generate JWT Token
            var token = GenerateJwtToken(user);

            return token;
        }

        // =====================================================
        // Generate JWT Token
        // =====================================================
        private string GenerateJwtToken(User user)
        {
            // Security key from appsettings.json
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    _configuration["Jwt:Key"]!));

            // Signing credentials
            var credentials =
                new SigningCredentials(
                    key,
                    SecurityAlgorithms.HmacSha256);

            // Claims stored inside token
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.FullName),

                new Claim(ClaimTypes.Email, user.Email),

                new Claim(ClaimTypes.Role, user.Role)
            };

            // Create token
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],

                audience: _configuration["Jwt:Audience"],

                claims: claims,

                expires: DateTime.Now.AddHours(2),

                signingCredentials: credentials
            );

            // Return token string
            return new JwtSecurityTokenHandler()
                .WriteToken(token);
        }
    }
}