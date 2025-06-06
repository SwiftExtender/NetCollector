using Microsoft.EntityFrameworkCore;
using NetFighter.Models;
using System;
using System.Reflection.Metadata;

namespace NetFighter.Data
{
    public class ApplicationDbContext : DbContext
    {
        private string DbPath { get; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            var _ = Model;
            Database.EnsureCreated();
        }
        //public ApplicationDbContext()
        //{
        //    var path = AppDomain.CurrentDomain.BaseDirectory;
        //    DbPath = System.IO.Path.Join(path, "data.db");
        //}
        public DbSet<Domains> Domains { get; set; }
        public DbSet<DomainsHosts> DomainsHosts { get; set; }
        public DbSet<Hosts> Hosts { get; set; }
        public DbSet<Keywords> Keywords { get; set; }
        public DbSet<Params> Params { get; set; }
        public DbSet<Ports> Ports { get; set; }
        public DbSet<Requests> Requests { get; set; }
        public DbSet<ScanProfiles> ScanProfiles { get; set; }
        public DbSet<ScanProfilesToolProfiles> ScanProfilesToolProfiles { get; set; }
        public DbSet<ToolProfiles> ToolProfiles { get; set; }
        public DbSet<Subnets> Subnets { get; set; }
        public DbSet<Tools> Tools { get; set; }
        public DbSet<Urls> Urls { get; set; }
        public DbSet<VhostsPorts> VhostsPorts { get; set; }
        public DbSet<Vhosts> Vhosts { get; set; }
        public DbSet<Notes> Notes { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite($"Data Source={DbPath}");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hosts>().HasIndex(e => e.Ip).IsUnique();
            modelBuilder.Entity<Ports>().HasIndex(e => new { e.Number, e.HostId }).IsUnique();
            modelBuilder.Entity<Domains>()
                .HasMany(e => e.DomainsHosts)
                .WithOne(e => e.Domains)
                .HasForeignKey(e => e.DomainId)
                .HasPrincipalKey(e => e.Id);
            modelBuilder.Entity<Hosts>()
                .HasMany(e => e.DomainsHosts)
                .WithOne(e => e.Hosts)
                .HasForeignKey(e => e.HostId)
                .HasPrincipalKey(e => e.Id);
            modelBuilder.Entity<Vhosts>()
                .HasMany(e => e.VhostPorts)
                .WithOne(e => e.Vhosts)
                .HasForeignKey(e => e.VhostId)
                .HasPrincipalKey(e => e.Id);
            modelBuilder.Entity<Ports>()
                .HasMany(e => e.VhostPorts)
                .WithOne(e => e.Ports)
                .HasForeignKey(e => e.PortId)
                .HasPrincipalKey(e => e.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}