﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using app.Infrastructure;

#nullable disable

namespace app.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("app.Domain.Entities.Amenities", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Amenity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PropertyId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("PropertyId");

                    b.ToTable("Amenities");
                });

            modelBuilder.Entity("app.Domain.Entities.HighLight", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("HighLightName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PropertyId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("PropertyId");

                    b.ToTable("HighLights");
                });

            modelBuilder.Entity("app.Domain.Entities.Leases", b =>
                {
                    b.Property<string>("LeaseId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Deposit")
                        .HasColumnType("float");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PropertyId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Rent")
                        .HasColumnType("float");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TenantId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LeaseId");

                    b.HasIndex("PropertyId");

                    b.HasIndex("TenantId")
                        .IsUnique();

                    b.ToTable("Leases");
                });

            modelBuilder.Entity("app.Domain.Entities.Location", b =>
                {
                    b.Property<string>("LocationId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LocationId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("app.Domain.Entities.Manager", b =>
                {
                    b.Property<string>("ManagerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ManagerCognitoId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ManagerEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ManagerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ManagerPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ManagerId");

                    b.ToTable("Managers");
                });

            modelBuilder.Entity("app.Domain.Entities.Property", b =>
                {
                    b.Property<string>("PropertyId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("ApplicationFee")
                        .HasColumnType("float");

                    b.Property<double?>("AverageRating")
                        .HasColumnType("float");

                    b.Property<double>("Baths")
                        .HasColumnType("float");

                    b.Property<int>("Beds")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsParkingIncluded")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPetsAllowed")
                        .HasColumnType("bit");

                    b.Property<string>("LocationId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ManagerCognitoId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ManagerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("NumberOfReviews")
                        .HasColumnType("int");

                    b.Property<DateTime>("PostedDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("PricePerMonth")
                        .HasColumnType("float");

                    b.Property<string>("PropertyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PropertyType")
                        .HasColumnType("int");

                    b.Property<double>("SquareFeet")
                        .HasColumnType("float");

                    b.HasKey("PropertyId");

                    b.HasIndex("LocationId");

                    b.HasIndex("ManagerId");

                    b.ToTable("Property");
                });

            modelBuilder.Entity("app.Domain.Entities.PropertyPhotos", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LocationId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PropertyId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("PropertyId");

                    b.ToTable("PropertyPhotos");
                });

            modelBuilder.Entity("app.Domain.Entities.RentApplication", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ApplicationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ApplicationStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("LeasedId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PropertyId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenantCognito")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenantsTenantId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("TenantsTenantId");

                    b.ToTable("RentApplications");
                });

            modelBuilder.Entity("app.Domain.Entities.Tenants", b =>
                {
                    b.Property<string>("TenantId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenantCognitoId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TenantId");

                    b.ToTable("Tenants");
                });

            modelBuilder.Entity("app.Domain.Entities.Amenities", b =>
                {
                    b.HasOne("app.Domain.Entities.Property", "Property")
                        .WithMany("Amenities")
                        .HasForeignKey("PropertyId");

                    b.Navigation("Property");
                });

            modelBuilder.Entity("app.Domain.Entities.HighLight", b =>
                {
                    b.HasOne("app.Domain.Entities.Property", "Property")
                        .WithMany("HighLights")
                        .HasForeignKey("PropertyId");

                    b.Navigation("Property");
                });

            modelBuilder.Entity("app.Domain.Entities.Leases", b =>
                {
                    b.HasOne("app.Domain.Entities.Property", "Property")
                        .WithMany()
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("app.Domain.Entities.Tenants", "Tenants")
                        .WithOne("Leases")
                        .HasForeignKey("app.Domain.Entities.Leases", "TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Property");

                    b.Navigation("Tenants");
                });

            modelBuilder.Entity("app.Domain.Entities.Property", b =>
                {
                    b.HasOne("app.Domain.Entities.Location", "Location")
                        .WithMany("Properties")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("app.Domain.Entities.Manager", "Manager")
                        .WithMany("Properties")
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("app.Domain.Entities.PropertyPhotos", b =>
                {
                    b.HasOne("app.Domain.Entities.Property", "Property")
                        .WithMany("Photos")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Property");
                });

            modelBuilder.Entity("app.Domain.Entities.RentApplication", b =>
                {
                    b.HasOne("app.Domain.Entities.Tenants", "Tenants")
                        .WithMany()
                        .HasForeignKey("TenantsTenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tenants");
                });

            modelBuilder.Entity("app.Domain.Entities.Location", b =>
                {
                    b.Navigation("Properties");
                });

            modelBuilder.Entity("app.Domain.Entities.Manager", b =>
                {
                    b.Navigation("Properties");
                });

            modelBuilder.Entity("app.Domain.Entities.Property", b =>
                {
                    b.Navigation("Amenities");

                    b.Navigation("HighLights");

                    b.Navigation("Photos");
                });

            modelBuilder.Entity("app.Domain.Entities.Tenants", b =>
                {
                    b.Navigation("Leases")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
