﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _09_EntityConfiguration.Context;

#nullable disable

namespace _09_EntityConfiguration.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221023123215_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.10");

            modelBuilder.Entity("_09_EntityConfiguration.Entities.Airport", b =>
                {
                    b.Property<int>("AirportID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AirportName")
                        .HasColumnType("TEXT");

                    b.HasKey("AirportID");

                    b.ToTable("Airports");
                });

            modelBuilder.Entity("_09_EntityConfiguration.Entities.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DepartmentName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("_09_EntityConfiguration.Entities.Flight", b =>
                {
                    b.Property<int>("FlightID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ArrivalAirportId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DepartureAirportId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FlightCode")
                        .HasColumnType("TEXT");

                    b.HasKey("FlightID");

                    b.HasIndex("ArrivalAirportId");

                    b.HasIndex("DepartureAirportId");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("_09_EntityConfiguration.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("Person ID");

                    b.Property<decimal?>("Bonus")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("TEXT")
                        .HasComputedColumnSql("[Salary]*[WorkingYear]*0.2");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValue(new DateTime(2022, 10, 23, 15, 32, 15, 239, DateTimeKind.Local).AddTicks(8846));

                    b.Property<int>("DepartmentId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<int>("Id2")
                        .HasColumnType("INTEGER");

                    b.Property<long>("IdentityNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Salary")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(5, 3)
                        .HasColumnType("TEXT")
                        .HasDefaultValue(5000m)
                        .HasComment("Without Tax Gross Salary");

                    b.Property<int>("WorkingYear")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("IdentityNumber")
                        .IsUnique();

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("_09_EntityConfiguration.Entities.Flight", b =>
                {
                    b.HasOne("_09_EntityConfiguration.Entities.Airport", "ArrivalAirport")
                        .WithMany("ArrivingFlights")
                        .HasForeignKey("ArrivalAirportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_09_EntityConfiguration.Entities.Airport", "DepartureAirport")
                        .WithMany("DepartingFlights")
                        .HasForeignKey("DepartureAirportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ArrivalAirport");

                    b.Navigation("DepartureAirport");
                });

            modelBuilder.Entity("_09_EntityConfiguration.Entities.Person", b =>
                {
                    b.HasOne("_09_EntityConfiguration.Entities.Department", "Department")
                        .WithMany("Persons")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("_09_EntityConfiguration.Entities.Airport", b =>
                {
                    b.Navigation("ArrivingFlights");

                    b.Navigation("DepartingFlights");
                });

            modelBuilder.Entity("_09_EntityConfiguration.Entities.Department", b =>
                {
                    b.Navigation("Persons");
                });
#pragma warning restore 612, 618
        }
    }
}