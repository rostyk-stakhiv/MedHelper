using MedHelper.DAL.Entities;
using Microsoft.EntityFrameworkCore;


namespace MedHelper.DAL
{
    public class MedHelperDBContext : DbContext
    {
        public DbSet<Composition> Compositions { get; set; }
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<MedicineInteraction> MedicineInteraction { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<PharmacotherapeuticGroup> PharmacotherapeuticGroups { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Username=fwvunaemuwigvf;Password=900bf9214a0ce43234324145f6f98545a958f0864df0cf8b63b5b00f3d62cd8e;Host=ec2-52-30-67-143.eu-west-1.compute.amazonaws.com;Port=5432;Database=debigcnpahp883;SSL Mode=Require;Trust Server Certificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(c => c.Roles)
                .WithMany(s => s.Users)
                .UsingEntity(j => j.ToTable("UserRole"));

            modelBuilder.Entity<Patient>()
                .HasOne(s => s.User)
                .WithMany(g => g.Patients)
                .HasForeignKey(s => s.UserId);

            modelBuilder.Entity<Medicine>()
                .HasOne(s => s.User)
                .WithMany(g => g.Medicines)
                .HasForeignKey(s => s.UserId);

            modelBuilder.Entity<Medicine>()
                .HasOne(s => s.Group)
                .WithMany(g => g.Medicines)
                .HasForeignKey(s => s.PharmacotherapeuticGroupId);

            modelBuilder.Entity<Patient>()
                .HasMany(c => c.Medicines)
                .WithMany(s => s.Patients)
                .UsingEntity(j => j.ToTable("PatientMedicine"));

            modelBuilder.Entity<Patient>()
                .HasMany(c => c.Diseases)
                .WithMany(s => s.Patients)
                .UsingEntity(j => j.ToTable("PatientDisease"));

            modelBuilder.Entity<Medicine>()
               .HasMany(c => c.Contraindications)
               .WithMany(s => s.MedicineContraindications)
               .UsingEntity(j => j.ToTable("MedicineContraindication"));

            modelBuilder.Entity<Medicine>()
                .HasMany(c => c.Compositions)
                .WithMany(s => s.Medicines)
                .UsingEntity(j => j.ToTable("MedicineComposition"));

            modelBuilder.Entity<MedicineInteraction>()
                .HasOne(bc => bc.Composition)
                .WithMany(b => b.MedicineInteractions)
                .HasForeignKey(bc => bc.CompositionId);

            modelBuilder.Entity<MedicineInteraction>()
                .HasOne(bc => bc.Medicine)
                .WithMany(c => c.MedicineInteractions)
                .HasForeignKey(bc => bc.MedicineId);


        }
    }
}
