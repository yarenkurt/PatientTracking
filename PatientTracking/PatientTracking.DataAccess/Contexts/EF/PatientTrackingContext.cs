using Microsoft.EntityFrameworkCore;
using PatientTracking.DataAccess.Extentions;
using PatientTracking.Entities.Concrete;

namespace PatientTracking.DataAccess.Contexts.EF
{
    public class PatientTrackingContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Degree> Degrees { get; set; }
        public DbSet<Deparment> Deparments { get; set; }
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<PatientDisease> PatientDiseases { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Person> Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("Server=.\\KURT; Database = PatientTracking; User=sa; Password=Yaren#1998; ");
            }
        }

        public PatientTrackingContext()
        {

        }
        public PatientTrackingContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb = mb.SetDataType();
            mb = mb.MapConfiguration();
            base.OnModelCreating(mb);
        }
    }
}
