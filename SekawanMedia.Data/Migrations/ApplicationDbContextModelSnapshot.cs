﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SekawanMedia.Data;

#nullable disable

namespace SekawanMedia.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SekawanMedia.Data.Domain.BookingApproval", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("ApprovedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("ApprovedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("BookingRequestId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("IsApproved")
                        .HasColumnType("bit");

                    b.Property<Guid>("MsUserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BookingRequestId");

                    b.HasIndex("MsUserId");

                    b.ToTable("BookingApprovals");
                });

            modelBuilder.Entity("SekawanMedia.Data.Domain.BookingRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BbmConsumption")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Driver")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<Guid>("MsVehicleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("RequestedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("RequestedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MsVehicleId");

                    b.ToTable("BookingRequests");
                });

            modelBuilder.Entity("SekawanMedia.Data.Domain.MsUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("DateOfBirth")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdCardNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("JoinedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("LastLogin")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("MaritalStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("MsUserRolesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nationality")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlaceOfBirth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePicture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sex")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MsUserRolesId");

                    b.ToTable("MsUsers");
                });

            modelBuilder.Entity("SekawanMedia.Data.Domain.MsUserRoles", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MsUserRoles");
                });

            modelBuilder.Entity("SekawanMedia.Data.Domain.MsVehicle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Bpkb")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Colours")
                        .HasColumnType("varchar(20)");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HullNumber")
                        .HasColumnType("varchar(7)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<Guid>("MsUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MsVehicleTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nopol")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("PurchasedAt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PurchasedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Stnk")
                        .HasColumnType("varchar(50)");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MsUserId");

                    b.HasIndex("MsVehicleTypeId");

                    b.ToTable("MsVehicles");
                });

            modelBuilder.Entity("SekawanMedia.Data.Domain.MsVehicleType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MsVehicleTypes");
                });

            modelBuilder.Entity("SekawanMedia.Data.Domain.ServiceHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<Guid>("MsVehicleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("ServiceAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("ServiceBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServiceIn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("TotalServiceFee")
                        .HasColumnType("float");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MsVehicleId");

                    b.ToTable("ServiceHistories");
                });

            modelBuilder.Entity("SekawanMedia.Data.Domain.BookingApproval", b =>
                {
                    b.HasOne("SekawanMedia.Data.Domain.BookingRequest", "BookingRequest")
                        .WithMany("BookingApprovals")
                        .HasForeignKey("BookingRequestId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SekawanMedia.Data.Domain.MsUser", "MsUser")
                        .WithMany("BookingApprovals")
                        .HasForeignKey("MsUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("BookingRequest");

                    b.Navigation("MsUser");
                });

            modelBuilder.Entity("SekawanMedia.Data.Domain.BookingRequest", b =>
                {
                    b.HasOne("SekawanMedia.Data.Domain.MsVehicle", "MsVehicle")
                        .WithMany("BookingRequests")
                        .HasForeignKey("MsVehicleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("MsVehicle");
                });

            modelBuilder.Entity("SekawanMedia.Data.Domain.MsUser", b =>
                {
                    b.HasOne("SekawanMedia.Data.Domain.MsUserRoles", "MsUserRoles")
                        .WithMany("MsUsers")
                        .HasForeignKey("MsUserRolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MsUserRoles");
                });

            modelBuilder.Entity("SekawanMedia.Data.Domain.MsVehicle", b =>
                {
                    b.HasOne("SekawanMedia.Data.Domain.MsUser", "MsUser")
                        .WithMany("MsVehicles")
                        .HasForeignKey("MsUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SekawanMedia.Data.Domain.MsVehicleType", "MsVehicleType")
                        .WithMany("MsVehicles")
                        .HasForeignKey("MsVehicleTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("MsUser");

                    b.Navigation("MsVehicleType");
                });

            modelBuilder.Entity("SekawanMedia.Data.Domain.ServiceHistory", b =>
                {
                    b.HasOne("SekawanMedia.Data.Domain.MsVehicle", "MsVehicle")
                        .WithMany("ServiceHistories")
                        .HasForeignKey("MsVehicleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("MsVehicle");
                });

            modelBuilder.Entity("SekawanMedia.Data.Domain.BookingRequest", b =>
                {
                    b.Navigation("BookingApprovals");
                });

            modelBuilder.Entity("SekawanMedia.Data.Domain.MsUser", b =>
                {
                    b.Navigation("BookingApprovals");

                    b.Navigation("MsVehicles");
                });

            modelBuilder.Entity("SekawanMedia.Data.Domain.MsUserRoles", b =>
                {
                    b.Navigation("MsUsers");
                });

            modelBuilder.Entity("SekawanMedia.Data.Domain.MsVehicle", b =>
                {
                    b.Navigation("BookingRequests");

                    b.Navigation("ServiceHistories");
                });

            modelBuilder.Entity("SekawanMedia.Data.Domain.MsVehicleType", b =>
                {
                    b.Navigation("MsVehicles");
                });
#pragma warning restore 612, 618
        }
    }
}
