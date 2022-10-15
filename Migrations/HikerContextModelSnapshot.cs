﻿// <auto-generated />
using HikerPals.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HikerPals.Migrations
{
    [DbContext(typeof(HikerContext))]
    partial class HikerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HikerPals.Models.Hiker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("AverageDailyMiles")
                        .HasColumnType("int");

                    b.Property<string>("TrailName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("YearsExperience")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Hikers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 45,
                            AverageDailyMiles = 15,
                            TrailName = "Low Branch",
                            YearsExperience = 15
                        });
                });

            modelBuilder.Entity("HikerPals.Models.Trail", b =>
                {
                    b.Property<int>("TrailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Distance")
                        .HasColumnType("float");

                    b.Property<int>("HikerId")
                        .HasColumnType("int");

                    b.Property<string>("TName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TrailId");

                    b.HasIndex("HikerId");

                    b.ToTable("Trails");

                    b.HasData(
                        new
                        {
                            TrailId = 1,
                            Distance = 2190.0,
                            HikerId = 1,
                            TName = "Appalacian Trail"
                        });
                });

            modelBuilder.Entity("HikerPals.Models.Trail", b =>
                {
                    b.HasOne("HikerPals.Models.Hiker", "Hiker")
                        .WithMany()
                        .HasForeignKey("HikerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
