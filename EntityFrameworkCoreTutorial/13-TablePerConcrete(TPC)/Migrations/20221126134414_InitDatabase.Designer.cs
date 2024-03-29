﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _13_TablePerConcrete_TPC_.Context;

#nullable disable

namespace _13TablePerConcreteTPC.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221126134414_InitDatabase")]
    partial class InitDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("_13_TablePerConcrete_TPC_.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable((string)null);

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("_13_TablePerConcrete_TPC_.Entities.Customer", b =>
                {
                    b.HasBaseType("_13_TablePerConcrete_TPC_.Entities.Person");

                    b.Property<string>("CompanyName")
                        .HasColumnType("TEXT");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("_13_TablePerConcrete_TPC_.Entities.Employee", b =>
                {
                    b.HasBaseType("_13_TablePerConcrete_TPC_.Entities.Person");

                    b.Property<string>("Department")
                        .HasColumnType("TEXT");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("_13_TablePerConcrete_TPC_.Entities.Technician", b =>
                {
                    b.HasBaseType("_13_TablePerConcrete_TPC_.Entities.Employee");

                    b.Property<string>("Branch")
                        .HasColumnType("TEXT");

                    b.ToTable("Technicians");
                });
#pragma warning restore 612, 618
        }
    }
}
