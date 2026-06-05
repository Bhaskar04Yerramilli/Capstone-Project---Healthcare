using HealthcareAnalytics.Web.ViewModels;

using Microsoft.AspNetCore.Mvc;

using System.Text;
using System.Text.Json;

namespace HealthcareAnalytics.Web.Controllers
{
    // Controller handles Login and Registration UI
    public class AccountController : Controller
    {
        private readonly HttpClient _httpClient;

        // Constructor Injection
        public AccountController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        // =====================================================
        // GET: Login Page
        // =====================================================
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // =====================================================
        // POST: Login User
        // =====================================================
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Convert model into JSON
            var jsonContent =
                new StringContent(
                    JsonSerializer.Serialize(model),
                    Encoding.UTF8,
                    "application/json");

            // Call API Login Endpoint
            var response =
                await _httpClient.PostAsync(
                    "https://localhost:7222/api/Auth/login",
                    jsonContent);

            // If login successful
            if (response.IsSuccessStatusCode)
            {
                var result =
                    await response.Content.ReadAsStringAsync();

                // Store token temporarily
                TempData["Token"] = result;

                return RedirectToAction("Index", "Home");
            }

            // Login failed
            ModelState.AddModelError("", "Invalid login.");

            return View(model);
        }

        // =====================================================
        // GET: Register Page
        // =====================================================
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // =====================================================
        // POST: Register User
        // =====================================================
        [HttpPost]
        public async Task<IActionResult> Register(
            RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Convert model into JSON
            var jsonContent =
                new StringContent(
                    JsonSerializer.Serialize(model),
                    Encoding.UTF8,
                    "application/json");

            // Call API Register Endpoint
            var response =
                await _httpClient.PostAsync(
                    "https://localhost:7222/api/Auth/register",
                    jsonContent);

            // If registration successful
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Login");
            }

            // Registration failed
            ModelState.AddModelError("", "Registration failed.");

            return View(model);
        }
    }
}