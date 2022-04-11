using MedHelper.DAL.Entities;
using Microsoft.EntityFrameworkCore;


namespace MedHelper.DAL
{
    public class MedHelperDB : DbContext
    {
        public DbSet<BaseEntity> Compositions { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Username=fwvunaemuwigvf;Password=900bf9214a0ce43234324145f6f98545a958f0864df0cf8b63b5b00f3d62cd8e;Host=ec2-52-30-67-143.eu-west-1.compute.amazonaws.com;Port=5432;Database=debigcnpahp883;SSL Mode=Require;Trust Server Certificate=true");
        }
    }
}
