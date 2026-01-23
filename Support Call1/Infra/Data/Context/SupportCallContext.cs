using Microsoft.EntityFrameworkCore;
using Support_Call1.Domain.Entities;
using Support_Call1.Infra.Data.Configuration;

namespace Support_Call1.Infra.Data.Context
{
    public class SupportCallContext : DbContext
    {
        public DbSet<Users> UsersSet { get; set; }
        public DbSet<Calls> CallsSet { get; set; }
        public DbSet<Technical> technicalSet {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsersConfiguration());
            modelBuilder.ApplyConfiguration(new CallsConfiguration());
            modelBuilder.ApplyConfiguration(new TechnicalConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string conection = "Server=localhost;Database=SupportCallDB;port=3306;uid=root;Password=;";

            optionsBuilder.UseMySql(conection, ServerVersion.AutoDetect(conection));
            base.OnConfiguring(optionsBuilder);
        }
    }
}
