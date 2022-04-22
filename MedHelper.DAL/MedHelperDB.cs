using MedHelper.DAL.Entities;
using Microsoft.EntityFrameworkCore;


namespace MedHelper.DAL
{
    public class MedHelperDB : DbContext
    {
        public DbSet<BaseEntity> Compositions { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Username=postgres;Password=0000;Host=localhost;Port=5432;Database=medhelper;");
        }
    }
}
