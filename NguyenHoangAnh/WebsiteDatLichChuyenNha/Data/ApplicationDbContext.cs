using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebsiteDichVuSuaNha.Models;

namespace WebsiteDichVuSuaNha.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<PricingSetting> PricingSettings { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure decimal precision for SQL Server
            modelBuilder.Entity<Booking>()
                .Property(b => b.EstimatedCost)
                .HasPrecision(18, 2);

            modelBuilder.Entity<PricingSetting>()
                .Property(p => p.BaseServiceFee)
                .HasPrecision(18, 2);

            // Configure Review relationships
            modelBuilder.Entity<Review>()
                .HasOne(r => r.Booking)
                .WithMany()
                .HasForeignKey(r => r.BookingId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany()
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Seed initial pricing data
            modelBuilder.Entity<PricingSetting>().HasData(
                new PricingSetting
                {
                    Id = 1,
                    BaseServiceFee = 200000,
                    UpdatedAt = new DateTime(2025, 11, 25, 0, 0, 0, DateTimeKind.Utc)
                }
            );
        }
    }
}

