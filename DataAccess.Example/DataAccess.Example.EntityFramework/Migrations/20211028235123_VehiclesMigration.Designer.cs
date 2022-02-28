﻿// <auto-generated />
using System;
using DataAccess.Example.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.Example.EntityFramework.Migrations
{
    [DbContext(typeof(VehiclesDataContext))]
    [Migration("20211028235123_VehiclesMigration")]
    partial class VehiclesMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("DataAccess.Example.Core.Color", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("varchar(5)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Colors");
                });

            modelBuilder.Entity("DataAccess.Example.Core.Incentive", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.ToTable("Incentives");
                });

            modelBuilder.Entity("DataAccess.Example.Core.Make", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("MakeId")
                        .HasColumnType("int");

                    b.Property<string>("MakeName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("ModelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MakeId");

                    b.HasIndex("ModelId");

                    b.ToTable("Makes");
                });

            modelBuilder.Entity("DataAccess.Example.Core.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("FirstProductionYear")
                        .HasColumnType("int");

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.HasKey("Id");

                    b.ToTable("Models");
                });

            modelBuilder.Entity("DataAccess.Example.Core.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("MakeId")
                        .HasColumnType("int");

                    b.Property<int?>("ModelId")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MakeId");

                    b.HasIndex("ModelId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("DataAccess.Example.Core.Make", b =>
                {
                    b.HasOne("DataAccess.Example.Core.Make", null)
                        .WithMany("Makes")
                        .HasForeignKey("MakeId");

                    b.HasOne("DataAccess.Example.Core.Model", null)
                        .WithMany("Makes")
                        .HasForeignKey("ModelId");
                });

            modelBuilder.Entity("DataAccess.Example.Core.Vehicle", b =>
                {
                    b.HasOne("DataAccess.Example.Core.Make", "Make")
                        .WithMany()
                        .HasForeignKey("MakeId");

                    b.HasOne("DataAccess.Example.Core.Model", "Model")
                        .WithMany()
                        .HasForeignKey("ModelId");

                    b.Navigation("Make");

                    b.Navigation("Model");
                });

            modelBuilder.Entity("DataAccess.Example.Core.Make", b =>
                {
                    b.Navigation("Makes");
                });

            modelBuilder.Entity("DataAccess.Example.Core.Model", b =>
                {
                    b.Navigation("Makes");
                });
#pragma warning restore 612, 618
        }
    }
}