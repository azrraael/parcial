using Microsoft.EntityFrameworkCore;
using parcial.Shared.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace parcial.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Ticket>().HasIndex(n => n.Id).IsUnique();
        }
    }
}