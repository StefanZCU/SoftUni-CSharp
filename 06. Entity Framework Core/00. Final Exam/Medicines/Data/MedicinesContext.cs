using Medicines.Data.Models;

namespace Medicines.Data
{
    using Microsoft.EntityFrameworkCore;
    public class MedicinesContext : DbContext
    {
        public MedicinesContext()
        {
        }

        public MedicinesContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Pharmacy> Pharmacies { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Medicine> Medicines { get; set; }

        public DbSet<PatientMedicine> PatientsMedicines { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString)
                    .UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientMedicine>(e =>
            {
                e.HasKey(pm => new { pm.PatientId, pm.MedicineId });
            });
        }
    }
}
