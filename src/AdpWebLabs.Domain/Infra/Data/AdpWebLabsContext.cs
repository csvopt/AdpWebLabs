using AdpWebLabs.Domain.Domain.Entities;
using AdpWebLabs.Domain.Infra.Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace AdpWebLabs.Domain.Infra.Data
{
    public class AdpWebLabsContext : DbContext
    {
        public AdpWebLabsContext() {}

        public AdpWebLabsContext(DbContextOptions<AdpWebLabsContext> options)
            :base(options) {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CalculatorConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("THE_CONNECTION_STRING");
        }

        public DbSet<Calculator> Calculators { get; set; }
    }
}
