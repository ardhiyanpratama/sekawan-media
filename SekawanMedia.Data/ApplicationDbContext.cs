using Microsoft.EntityFrameworkCore;
using SekawanMedia.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekawanMedia.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public virtual DbSet<MsUser> MsUsers { get; set; } = null!;
        public virtual DbSet<MsUserRoles> MsUserRoles { get; set; } = null!;
        public virtual DbSet<MsVehicle> MsVehicles { get; set; } = null!;
        public virtual DbSet<MsVehicleType> MsVehicleTypes { get; set; } = null!;
        public virtual DbSet<ServiceHistory> ServiceHistories { get; set; } = null!;
        public virtual DbSet<BookingRequest> BookingRequests { get; set; } = null!;
        public virtual DbSet<BookingApproval> BookingApprovals { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<MsUser>(entity =>
            {
                entity.HasOne(e => e.MsUserRoles)
                    .WithMany(e => e.MsUsers)
                    .HasForeignKey(e => e.MsUserRolesId)
                    .IsRequired(true);
            });

            modelBuilder.Entity<MsVehicle>(entity =>
            {
                entity.HasOne(e => e.MsUser)
                   .WithMany(e => e.MsVehicles)
                   .HasForeignKey(e => e.MsUserId)
                   .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.MsVehicleType)
                   .WithMany(e => e.MsVehicles)
                   .HasForeignKey(e => e.MsVehicleTypeId)
                   .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<ServiceHistory>(entity =>
            {
                entity.HasOne(e => e.MsVehicle)
                    .WithMany(e => e.ServiceHistories)
                    .HasForeignKey(e => e.MsVehicleId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<BookingRequest>(entity =>
            {
                entity.HasOne(e => e.MsVehicle)
                    .WithMany(e => e.BookingRequests)
                    .HasForeignKey(e => e.MsVehicleId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<BookingApproval>(entity =>
            {
                entity.HasOne(e => e.BookingRequest)
                    .WithMany(e => e.BookingApprovals)
                    .HasForeignKey(e => e.BookingRequestId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.MsUser)
                    .WithMany(e => e.BookingApprovals)
                    .HasForeignKey(e => e.MsUserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            base.OnModelCreating(modelBuilder);

        }

    }
}
