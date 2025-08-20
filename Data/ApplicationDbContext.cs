using EventManagement.Api.Models;
using EventManagement.Models;
using EventManagement.Models.AdminModel;
using EventManagement.Models.BookingModel;
using EventManagement.Models.PaymentModel;
using EventManagement.Models.UserModel;
using Microsoft.EntityFrameworkCore;

namespace EventManagement.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    // Vendor → EventCategory (many-to-one)
    modelBuilder.Entity<Vendor>()
        .HasOne(v => v.EventCategory)
        .WithMany()
        .HasForeignKey(v => v.EventCategoryId)
        .OnDelete(DeleteBehavior.Restrict);

    // Vendor → VendorServices (one-to-many)
    modelBuilder.Entity<Vendor>()
        .HasMany(v => v.VendorServices)
        .WithOne(vs => vs.Vendor)
        .HasForeignKey(vs => vs.VendorId)
        .OnDelete(DeleteBehavior.Cascade);

    // Vendor → BookingRequests (one-to-many)
    modelBuilder.Entity<Vendor>()
        .HasMany(v => v.BookingRequests)
        .WithOne(br => br.Vendor)
        .HasForeignKey(br => br.VendorId)
        .OnDelete(DeleteBehavior.Restrict);

    // BookingRequest → User (many-to-one)
    modelBuilder.Entity<BookingRequest>()
        .HasOne(br => br.User)
        .WithMany() // or .WithMany(u => u.BookingRequests) if defined
        .HasForeignKey(br => br.UserId)
        .OnDelete(DeleteBehavior.Restrict);

    // BookingRequest → Vendor (many-to-one)
    modelBuilder.Entity<BookingRequest>()
        .HasOne(br => br.Vendor)
        .WithMany() // or .WithMany(v => v.BookingRequests) if defined
        .HasForeignKey(br => br.VendorId)
        .OnDelete(DeleteBehavior.Restrict);
}




public DbSet<BookingRequest> BookingRequests { get; set; }
public DbSet<EventCategory> EventCategories { get; set; }
public DbSet<Quotation> Quotations { get; set; }
public DbSet<Role> Roles { get; set; }
public DbSet<User> Users { get; set; }
public DbSet<Vendor> Vendors { get; set; }
public DbSet<VendorService> VendorServices { get; set; }
public DbSet<Payment> Payments { get; set; }

    
    }
}
