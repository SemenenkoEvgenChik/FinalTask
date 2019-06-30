using Hospital.DAL.Entities;
using Hospital.DAL.Helpers;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Hospital.DAL
{
    public class HospitalContext : IdentityDbContext<ApplicationUser>
    {
        public HospitalContext() : base("DefaultConnection")
        {
            Database.SetInitializer(new HospitalContextInitializer());
        }
        public static HospitalContext Create()
        {
            return new HospitalContext();
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<HistoryIllness> HistoryIllnesses { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<Patient> Patients { get; set; }
    }
}
