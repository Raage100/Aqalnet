﻿// <auto-generated />
using System;
using Aqalnet.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Aqalnet.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240304140121_intial")]
    partial class intial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Aqalnet.Domain.Companies.Agent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobileNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Agent");
                });

            modelBuilder.Entity("Aqalnet.Domain.Companies.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Companies", (string)null);
                });

            modelBuilder.Entity("Aqalnet.Domain.Propertys.Apartment", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PropertyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Floor")
                        .HasColumnType("int");

                    b.Property<bool>("HasBalcony")
                        .HasColumnType("bit");

                    b.Property<bool>("HasElevator")
                        .HasColumnType("bit");

                    b.Property<bool>("HasParking")
                        .HasColumnType("bit");

                    b.Property<decimal>("LivingArea")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("NumberOfRooms")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfToilets")
                        .HasColumnType("int");

                    b.Property<decimal>("PricePerSquareMeter")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateOnly>("YearBuilt")
                        .HasColumnType("date");

                    b.HasKey("Id", "PropertyId");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Apartments", (string)null);
                });

            modelBuilder.Entity("Aqalnet.Domain.Propertys.House", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PropertyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("BuildingArea")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("HasGarage")
                        .HasColumnType("bit");

                    b.Property<bool>("HasParking")
                        .HasColumnType("bit");

                    b.Property<int>("NumberOfFloors")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfRooms")
                        .HasColumnType("int");

                    b.Property<decimal>("PlotArea")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PricePerSquareMeter")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateOnly>("YearBuilt")
                        .HasColumnType("date");

                    b.HasKey("Id", "PropertyId");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Houses", (string)null);
                });

            modelBuilder.Entity("Aqalnet.Domain.Propertys.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Alt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PropertyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PropertyId");

                    b.ToTable("Images", (string)null);
                });

            modelBuilder.Entity("Aqalnet.Domain.Propertys.Land", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PropertyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Area")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PricePerSquareMeter")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id", "PropertyId");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Lands", (string)null);
                });

            modelBuilder.Entity("Aqalnet.Domain.Propertys.Property", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateOnly>("DatePublished")
                        .HasColumnType("date");

                    b.Property<bool>("IsPublished")
                        .HasColumnType("bit");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PropertyType")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("UserId");

                    b.ToTable("Properties", (string)null);
                });

            modelBuilder.Entity("Aqalnet.Domain.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateOnly>("CreatedAt")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobileNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<DateOnly?>("UpdatedAt")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Aqalnet.Domain.Companies.Agent", b =>
                {
                    b.HasOne("Aqalnet.Domain.Companies.Company", null)
                        .WithMany("Agents")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Aqalnet.Domain.Companies.Company", b =>
                {
                    b.OwnsOne("Aqalnet.Domain.Companies.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("CompanyId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("City");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Street");

                            b1.HasKey("CompanyId");

                            b1.ToTable("Companies");

                            b1.WithOwner()
                                .HasForeignKey("CompanyId");
                        });

                    b.OwnsOne("Aqalnet.Domain.Companies.Logo", "Logo", b1 =>
                        {
                            b1.Property<Guid>("CompanyId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Url")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("LogoUrl");

                            b1.HasKey("CompanyId");

                            b1.ToTable("Companies");

                            b1.WithOwner()
                                .HasForeignKey("CompanyId");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Logo");
                });

            modelBuilder.Entity("Aqalnet.Domain.Propertys.Apartment", b =>
                {
                    b.HasOne("Aqalnet.Domain.Propertys.Property", null)
                        .WithOne("Apartment")
                        .HasForeignKey("Aqalnet.Domain.Propertys.Apartment", "Id");
                });

            modelBuilder.Entity("Aqalnet.Domain.Propertys.House", b =>
                {
                    b.HasOne("Aqalnet.Domain.Propertys.Property", null)
                        .WithOne("House")
                        .HasForeignKey("Aqalnet.Domain.Propertys.House", "Id");
                });

            modelBuilder.Entity("Aqalnet.Domain.Propertys.Image", b =>
                {
                    b.HasOne("Aqalnet.Domain.Propertys.Property", null)
                        .WithMany("_images")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Aqalnet.Domain.Propertys.Land", b =>
                {
                    b.HasOne("Aqalnet.Domain.Propertys.Property", null)
                        .WithOne("Land")
                        .HasForeignKey("Aqalnet.Domain.Propertys.Land", "Id");
                });

            modelBuilder.Entity("Aqalnet.Domain.Propertys.Property", b =>
                {
                    b.HasOne("Aqalnet.Domain.Companies.Company", null)
                        .WithMany()
                        .HasForeignKey("CompanyId");

                    b.HasOne("Aqalnet.Domain.Users.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Aqalnet.Domain.Propertys.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("PropertyId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("City");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Street");

                            b1.HasKey("PropertyId");

                            b1.ToTable("Properties");

                            b1.WithOwner()
                                .HasForeignKey("PropertyId");
                        });

                    b.Navigation("Address")
                        .IsRequired();
                });

            modelBuilder.Entity("Aqalnet.Domain.Users.User", b =>
                {
                    b.HasOne("Aqalnet.Domain.Companies.Company", null)
                        .WithMany()
                        .HasForeignKey("CompanyId");

                    b.OwnsOne("Aqalnet.Domain.Users.ProfilePicture", "ProfilePicture", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Url")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("ProfilePictureUrl");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("ProfilePicture");
                });

            modelBuilder.Entity("Aqalnet.Domain.Companies.Company", b =>
                {
                    b.Navigation("Agents");
                });

            modelBuilder.Entity("Aqalnet.Domain.Propertys.Property", b =>
                {
                    b.Navigation("Apartment");

                    b.Navigation("House");

                    b.Navigation("Land");

                    b.Navigation("_images");
                });
#pragma warning restore 612, 618
        }
    }
}