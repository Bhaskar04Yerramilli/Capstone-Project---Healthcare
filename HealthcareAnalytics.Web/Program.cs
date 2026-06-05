using HealthcareAnalytics.Core.Interfaces;
using HealthcareAnalytics.Data.Context;
using HealthcareAnalytics.Data.Repositories;
using HealthcareAnalytics.Service.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// ==========================================
// Add MVC Services
// ==========================================

builder.Services.AddControllersWithViews();


// ==========================================
// Register HttpClient
// ==========================================

builder.Services.AddHttpClient();


// ==========================================
// Database Connection
// ==========================================

builder.Services.AddDbContext<HealthcareDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));


// ==========================================
// Repository Registration
// ==========================================

// Patient Repository
builder.Services.AddScoped<IPatientRepository, PatientRepository>();

// Appointment Repository
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();

// Doctor Repository
builder.Services.AddScoped<DoctorRepository>();


// ==========================================
// Service Registration
// ==========================================

// Patient Service
builder.Services.AddScoped<PatientService>();

// Appointment Service
builder.Services.AddScoped<AppointmentService>();


// ==========================================
// Build Application
// ==========================================

var app = builder.Build();


// ==========================================
// Configure HTTP Request Pipeline
// ==========================================

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


// ==========================================
// Default Route
// ==========================================

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


// ==========================================
// Run Application
// ==========================================

app.Run();