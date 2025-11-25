using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebsiteDatLichChuyenNha.Models;

namespace WebsiteDatLichChuyenNha.Data
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
                    UpdatedAt = DateTime.Now
                }
            );
        }
    }
}

