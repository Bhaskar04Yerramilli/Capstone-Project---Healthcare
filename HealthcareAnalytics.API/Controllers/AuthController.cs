using HealthcareAnalytics.Core.DTOs;
using HealthcareAnalytics.Core.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace HealthcareAnalytics.API.Controllers
{
    // API Controller for Authentication operations
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        // Authentication Service object
        private readonly IAuthService _authService;

        // Constructor Injection
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // =====================================================
        // POST: api/auth/register
        // Register new user
        // =====================================================
        [HttpPost("register")]
        public async Task<IActionResult> Register(
            RegisterRequestDto request)
        {
            try
            {
                // Validate model
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // Register user
                var result =
                    await _authService.RegisterAsync(request);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // =====================================================
        // POST: api/auth/login
        // Login user and generate JWT token
        // =====================================================
        [HttpPost("login")]
        public async Task<IActionResult> Login(
            LoginRequestDto request)
        {
            try
            {
                // Validate model
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // Generate token
                var token =
                    await _authService.LoginAsync(request);

                return Ok(new
                {
                    Token = token
                });
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}