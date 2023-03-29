using Microsoft.EntityFrameworkCore;
using WeatherApp2023.BusinessModels;

namespace WeatherApp2023.Infrastructure.Persistence
{
    public class DatapointContext : DbContext
    {
        public DbSet<DataPoint> DataPoints { get; set; }

        public DatapointContext(DbContextOptions<DatapointContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DataPoint>().ToTable("DataPoint");
        }
    }
}
