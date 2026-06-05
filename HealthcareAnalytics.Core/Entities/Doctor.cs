namespace HealthcareAnalytics.Core.Entities
{
    // Represents doctor details
    public class Doctor
    {
        // Primary Key
        public int DoctorId { get; set; }

        // Doctor name
        public string Name { get; set; } = string.Empty;

        // Doctor specialization
        public string Specialization { get; set; } = string.Empty;

        // Years of experience
        public int Experience { get; set; }

        // Navigation Property
        // One Doctor can have many appointments
        public ICollection<Appointment>? Appointments { get; set; }
    }
}