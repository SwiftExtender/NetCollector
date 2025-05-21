using Microsoft.EntityFrameworkCore;
using NetFighter.Models;

namespace NetFighter.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Domains> Domains { get; set; }
        public DbSet<DomainsHosts> DomainsHosts { get; set; }
        public DbSet<Hosts> Hosts { get; set; }
        public DbSet<Keywords> Keywords { get; set; }
        public DbSet<Params> Params { get; set; }
        public DbSet<Ports> Ports { get; set; }
        public DbSet<Requests> Requests { get; set; }
        public DbSet<ScanProfiles> ScanProfiles { get; set; }
        public DbSet<ScanProfilesStartupProfiles> ScanProfilesStartupProfiles { get; set; }
        public DbSet<StartupProfiles> StartupProfiles { get; set; }
        public DbSet<Subnets> Subnets { get; set; }
        public DbSet<Tools> Tools { get; set; }
        public DbSet<Urls> Urls { get; set; }
        public DbSet<VhostPorts> VhostPorts { get; set; }
        public DbSet<Vhosts> Vhosts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Add model configurations here if needed
        }
    }
}