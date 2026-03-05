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
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new CallsConfiguration());
            modelBuilder.ApplyConfiguration(new TechnicalConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string conection = "server=localhost;port=3306;database=SupportCallDB;user=root;password=;";

            optionsBuilder.UseMySql(conection, ServerVersion.AutoDetect(conection));
            base.OnConfiguring(optionsBuilder);
        }
    }
}
