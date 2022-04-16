using MedHelper.DAL.Entities;
using Microsoft.EntityFrameworkCore;


namespace MedHelper.DAL
{
    public class MedHelperDB : DbContext
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
    }
}
