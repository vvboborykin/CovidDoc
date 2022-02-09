﻿// <auto-generated />
using CovidDoc.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CovidDoc.Model.Migrations
{
    [DbContext(typeof(CovidDocModel))]
    [Migration("20220125193439_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("ProductVersion", "5.0.13");

            modelBuilder.Entity("CovidDoc.Model.Organization", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsHospital")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(true);

                    b.Property<bool>("IsLab")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<string>("Orgn")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("Orgn")
                        .IsUnique();

                    b.ToTable("Organization");
                });
#pragma warning restore 612, 618
        }
    }
}