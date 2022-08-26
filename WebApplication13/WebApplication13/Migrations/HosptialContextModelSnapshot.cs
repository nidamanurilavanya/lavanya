﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication13.Models;

#nullable disable

namespace WebApplication13.Migrations
{
    [DbContext(typeof(HosptialContext))]
    partial class HosptialContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebApplication13.Models.Appointement", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<DateTime>("AppointDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("docid")
                        .HasColumnType("int");

                    b.Property<int>("ptid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("docid");

                    b.HasIndex("ptid");

                    b.ToTable("appointements");
                });

            modelBuilder.Entity("WebApplication13.Models.Doctor", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("speciality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("WebApplication13.Models.patient", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("mob")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("patients");
                });

            modelBuilder.Entity("WebApplication13.Models.Appointement", b =>
                {
                    b.HasOne("WebApplication13.Models.Doctor", "doc")
                        .WithMany()
                        .HasForeignKey("docid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication13.Models.patient", "pt")
                        .WithMany()
                        .HasForeignKey("ptid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("doc");

                    b.Navigation("pt");
                });
#pragma warning restore 612, 618
        }
    }
}
