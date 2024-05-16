namespace PortAPI.Data
{
    using Microsoft.EntityFrameworkCore;
    using PortAPI.Models;

    public class PortDbContext : DbContext
    {
        public PortDbContext(DbContextOptions<PortDbContext> options) : base(options) { }

        public DbSet<ShipArrival> Arrivees { get; set; }
        public DbSet<ShipDeparture> Departs { get; set; }
    }

}
