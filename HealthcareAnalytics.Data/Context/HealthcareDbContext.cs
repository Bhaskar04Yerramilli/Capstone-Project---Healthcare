using HealthcareAnalytics.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace HealthcareAnalytics.Data.Context
{
    // DbContext acts as bridge between application and database
    public class HealthcareDbContext : DbContext
    {
        // Constructor for dependency injection
        public HealthcareDbContext(DbContextOptions<HealthcareDbContext> options)
            : base(options)
        {
        }

        // Represents Users table
        public DbSet<User> Users { get; set; }

        // Represents Patients table
        public DbSet<Patient> Patients { get; set; }

        // Represents Doctors table
        public DbSet<Doctor> Doctors { get; set; }

        // Represents Appointments table
        public DbSet<Appointment> Appointments { get; set; }

        // Configure relationships and constraints
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // One Patient -> Many Appointments
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId);

            // One Doctor -> Many Appointments
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorId);
        }
    }
}