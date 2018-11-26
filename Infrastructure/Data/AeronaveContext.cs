using System.IO;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Infrastructure.EntityConfig;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Data
{
    public class AeronaveContext : DbContext
    {
        public DbSet<Aeronave> Aeronaves { get; set; }

        public AeronaveContext(DbContextOptions<AeronaveContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AeronaveConfig());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //get the configuration from the app settings
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            //// define the database to use            
            //optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}
