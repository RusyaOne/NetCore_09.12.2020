﻿// <auto-generated />
using Infestation.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infestation.Migrations
{
    [DbContext(typeof(InfestationDbContext))]
    [Migration("20201221193000_Seed initial data")]
    partial class Seedinitialdata
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("Infestation.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("DeadCount")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Population")
                        .HasColumnType("int");

                    b.Property<int>("RecoveredCount")
                        .HasColumnType("int");

                    b.Property<int>("SickCount")
                        .HasColumnType("int");

                    b.Property<bool>("Vaccine")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DeadCount = 317729,
                            Name = "US",
                            Population = 328200000,
                            RecoveredCount = 16800450,
                            SickCount = 17860634,
                            Vaccine = false
                        },
                        new
                        {
                            Id = 2,
                            DeadCount = 145810,
                            Name = "India",
                            Population = 1353150536,
                            RecoveredCount = 9606111,
                            SickCount = 10055560,
                            Vaccine = false
                        },
                        new
                        {
                            Id = 3,
                            DeadCount = 186764,
                            Name = "Brazil",
                            Population = 209500000,
                            RecoveredCount = 6409986,
                            SickCount = 7238600,
                            Vaccine = false
                        });
                });

            modelBuilder.Entity("Infestation.Models.Human", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsSick")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Humans");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 38,
                            CountryId = 1,
                            FirstName = "Obi-wan",
                            Gender = "Male",
                            IsSick = false,
                            LastName = "Kenobi"
                        },
                        new
                        {
                            Id = 2,
                            Age = 54,
                            CountryId = 1,
                            FirstName = "Sanwise",
                            Gender = "Male",
                            IsSick = false,
                            LastName = "Gamgee"
                        },
                        new
                        {
                            Id = 3,
                            Age = 30,
                            CountryId = 3,
                            FirstName = "Hose",
                            Gender = "Male",
                            IsSick = true,
                            LastName = "Rodriges"
                        },
                        new
                        {
                            Id = 4,
                            Age = 43,
                            CountryId = 3,
                            FirstName = "Consuela",
                            Gender = "Female",
                            IsSick = false,
                            LastName = "Tridana"
                        },
                        new
                        {
                            Id = 5,
                            Age = 25,
                            CountryId = 3,
                            FirstName = "Ana",
                            Gender = "Female",
                            IsSick = true,
                            LastName = "Cormelia"
                        },
                        new
                        {
                            Id = 6,
                            Age = 84,
                            CountryId = 1,
                            FirstName = "Thomas",
                            Gender = "Male",
                            IsSick = true,
                            LastName = "Edison"
                        });
                });

            modelBuilder.Entity("Infestation.Models.Human", b =>
                {
                    b.HasOne("Infestation.Models.Country", "Country")
                        .WithMany("Humans")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Infestation.Models.Country", b =>
                {
                    b.Navigation("Humans");
                });
#pragma warning restore 612, 618
        }
    }
}
