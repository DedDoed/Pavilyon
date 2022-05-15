﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pavilyon.Persistence;

namespace Pavilyon.WebApi.Migrations
{
    [DbContext(typeof(ProjectsDbContext))]
    partial class ProjectsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("Pavilyon.Domain.Attachment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Path")
                        .HasColumnType("longtext");

                    b.Property<Guid?>("ProjectId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Attachment");
                });

            modelBuilder.Entity("Pavilyon.Domain.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CreatorId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("ProjectName")
                        .HasColumnType("longtext");

                    b.Property<string>("ShortDescription")
                        .HasColumnType("longtext");

                    b.Property<string>("Tags")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Pavilyon.Domain.Attachment", b =>
                {
                    b.HasOne("Pavilyon.Domain.Project", null)
                        .WithMany("Attachments")
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("Pavilyon.Domain.Project", b =>
                {
                    b.Navigation("Attachments");
                });
#pragma warning restore 612, 618
        }
    }
}
