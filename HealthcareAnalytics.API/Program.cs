using HealthcareAnalytics.Core.Interfaces;

using HealthcareAnalytics.Data.Context;
using HealthcareAnalytics.Data.Repositories;

using HealthcareAnalytics.Service.Services;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


// ======================================================
// Add Controller Services
// ======================================================
// Enables API Controllers
// Configures JSON serialization to ignore circular references
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler =
            ReferenceHandler.IgnoreCycles;
    });


// ======================================================
// Swagger / OpenAPI Configuration
// ======================================================
// Swagger helps test APIs in browser
builder.Services.AddEndpointsApiExplorer();
// Configure Swagger with JWT Authentication
builder.Services.AddSwaggerGen(options =>
{
    // Define JWT Authentication scheme
    options.AddSecurityDefinition("Bearer",
        new Microsoft.OpenApi.Models.OpenApiSecurityScheme
        {
            Name = "Authorization",

            Type =
                Microsoft.OpenApi.Models.SecuritySchemeType.Http,

            Scheme = "bearer",

            BearerFormat = "JWT",

            In = Microsoft.OpenApi.Models.ParameterLocation.Header,

            Description =
                "Enter JWT Token like: Bearer {your token}"
        });

    // Apply JWT Authentication globally
    options.AddSecurityRequirement(
        new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
        {
            {
                new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Reference =
                        new Microsoft.OpenApi.Models.OpenApiReference
                        {
                            Type =
                                Microsoft.OpenApi.Models.ReferenceType
                                .SecurityScheme,

                            Id = "Bearer"
                        }
                },
                Array.Empty<string>()
            }
        });
});


// ======================================================
// Database Configuration
// ======================================================
// Connects application to SQL Server using EF Core
builder.Services.AddDbContext<HealthcareDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));


// ======================================================
// Dependency Injection - Patient Repository
// ======================================================
// Registers PatientRepository for database operations
builder.Services.AddScoped<IPatientRepository, PatientRepository>();


// ======================================================
// Dependency Injection - Patient Service
// ======================================================
// Registers PatientService for business logic
builder.Services.AddScoped<IPatientService, PatientService>();


// ======================================================
// Dependency Injection - Appointment Repository
// ======================================================
// Registers AppointmentRepository for appointment DB operations
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();


// ======================================================
// Dependency Injection - Appointment Service
// ======================================================
// Registers AppointmentService for appointment business logic
builder.Services.AddScoped<IAppointmentService, AppointmentService>();


// ======================================================
// Dependency Injection - Authentication Repository
// ======================================================
// Registers AuthRepository for authentication DB operations
builder.Services.AddScoped<IAuthRepository, AuthRepository>();


// ======================================================
// Dependency Injection - Authentication Service
// ======================================================
// Registers AuthService for authentication business logic
builder.Services.AddScoped<IAuthService, AuthService>();


// ======================================================
// JWT Authentication Configuration
// ======================================================
// Configures JWT token validation
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            // Validate token issuer
            ValidateIssuer = true,

            // Validate token audience
            ValidateAudience = true,

            // Validate token expiration
            ValidateLifetime = true,

            // Validate secret signing key
            ValidateIssuerSigningKey = true,

            // Issuer value from appsettings.json
            ValidIssuer = builder.Configuration["Jwt:Issuer"],

            // Audience value from appsettings.json
            ValidAudience = builder.Configuration["Jwt:Audience"],

            // Secret key for JWT signing
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
        };
    });


// ======================================================
// Authorization Services
// ======================================================
// Enables role-based authorization
builder.Services.AddAuthorization();


// ======================================================
// Build Application
// ======================================================
var app = builder.Build();


// ======================================================
// Swagger Middleware
// ======================================================
// Enables Swagger only in Development mode
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// ======================================================
// HTTPS Redirection Middleware
// ======================================================
// Redirects HTTP requests to HTTPS
app.UseHttpsRedirection();


// ======================================================
// Authentication Middleware
// ======================================================
// Validates JWT tokens before API access
app.UseAuthentication();


// ======================================================
// Authorization Middleware
// ======================================================
// Checks roles and permissions
app.UseAuthorization();


// ======================================================
// Map Controller Endpoints
// ======================================================
// Maps API routes to controllers
app.MapControllers();


// ======================================================
// Run Application
// ======================================================
app.Run();