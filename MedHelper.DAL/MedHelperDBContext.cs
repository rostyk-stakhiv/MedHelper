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
            modelBuilder.Entity<UserRole>()
                .HasOne(bc => bc.User)
                .WithMany(b => b.UserRoles)
                .HasForeignKey(bc => bc.UserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(bc => bc.Role)
                .WithMany(c => c.UserRoles)
                .HasForeignKey(bc => bc.RoleId);

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

            modelBuilder.Entity<PatientMedicine>()
                .HasOne(bc => bc.Patient)
                .WithMany(b => b.PatientMedicines)
                .HasForeignKey(bc => bc.PatientId);

            modelBuilder.Entity<PatientMedicine>()
                .HasOne(bc => bc.Medicine)
                .WithMany(c => c.PatientMedicines)
                .HasForeignKey(bc => bc.MedicineId);


            modelBuilder.Entity<PatientDisease>()
                            .HasOne(bc => bc.Patient)
                            .WithMany(b => b.PatientDiseases)
                            .HasForeignKey(bc => bc.PatientId);

            modelBuilder.Entity<PatientDisease>()
                .HasOne(bc => bc.Disease)
                .WithMany(c => c.PatientDiseases)
                .HasForeignKey(bc => bc.DiseaseId);

            modelBuilder.Entity<MedicineContraindication>()
                           .HasOne(bc => bc.Medicine)
                           .WithMany(b => b.MedicineContraindications)
                           .HasForeignKey(bc => bc.MedicineId);

            modelBuilder.Entity<MedicineContraindication>()
                .HasOne(bc => bc.Contraindication)
                .WithMany(c => c.MedicineContraindications)
                .HasForeignKey(bc => bc.ContraindicationId);

            modelBuilder.Entity<MedicineComposition>()
                .HasOne(bc => bc.Composition)
                .WithMany(b => b.MedicineCompositions)
                .HasForeignKey(bc => bc.CompositionId);

            modelBuilder.Entity<MedicineComposition>()
                .HasOne(bc => bc.Medicine)
                .WithMany(c => c.MedicineCompositions)
                .HasForeignKey(bc => bc.MedicineId);

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
