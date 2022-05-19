﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pavilyon.Persistence;

namespace Pavilyon.WebApi.Migrations
{
    [DbContext(typeof(ProjectsDbContext))]
    [Migration("20220519135700_addEntities")]
    partial class addEntities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("ProjectId");

                    b.ToTable("Attachments");
                });

            modelBuilder.Entity("Pavilyon.Domain.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Contacts")
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("ProjectName")
                        .HasColumnType("longtext");

                    b.Property<string>("ProjectObjectives")
                        .HasColumnType("longtext");

                    b.Property<string>("ProjectTargets")
                        .HasColumnType("longtext");

                    b.Property<string>("RequieredPersonal")
                        .HasColumnType("longtext");

                    b.Property<string>("ShortDescription")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Pavilyon.Domain.ProjectMember", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("IsCreator")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("char(36)");

                    b.Property<string>("ProjectRole")
                        .HasColumnType("longtext");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("ProjectId");

                    b.HasIndex("UserId");

                    b.ToTable("ProjectMembers");
                });

            modelBuilder.Entity("Pavilyon.Domain.Report", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Content")
                        .HasColumnType("longtext");

                    b.Property<string>("ReportName")
                        .HasColumnType("longtext");

                    b.Property<Guid?>("SenderId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("StageId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("SenderId");

                    b.HasIndex("StageId");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("Pavilyon.Domain.Stage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("FinishDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("ProjectId")
                        .HasColumnType("char(36)");

                    b.Property<string>("StageName")
                        .HasColumnType("longtext");

                    b.Property<int>("StageStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("ProjectId");

                    b.ToTable("Stages");
                });

            modelBuilder.Entity("Pavilyon.Domain.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("TagName")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Pavilyon.Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("AboutMe")
                        .HasColumnType("longtext");

                    b.Property<string>("Avatar")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<string>("MiddleName")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ProjectMemberStage", b =>
                {
                    b.Property<Guid>("ProjectMembersId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("StagesId")
                        .HasColumnType("char(36)");

                    b.HasKey("ProjectMembersId", "StagesId");

                    b.HasIndex("StagesId");

                    b.ToTable("ProjectMemberStage");
                });

            modelBuilder.Entity("ProjectTag", b =>
                {
                    b.Property<Guid>("ProjectsId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("TagsId")
                        .HasColumnType("char(36)");

                    b.HasKey("ProjectsId", "TagsId");

                    b.HasIndex("TagsId");

                    b.ToTable("ProjectTag");
                });

            modelBuilder.Entity("Pavilyon.Domain.Attachment", b =>
                {
                    b.HasOne("Pavilyon.Domain.Project", "Project")
                        .WithMany("Attachments")
                        .HasForeignKey("ProjectId");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Pavilyon.Domain.ProjectMember", b =>
                {
                    b.HasOne("Pavilyon.Domain.Project", "Project")
                        .WithMany("Team")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pavilyon.Domain.User", "User")
                        .WithMany("ProjectMembers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Pavilyon.Domain.Report", b =>
                {
                    b.HasOne("Pavilyon.Domain.ProjectMember", "Sender")
                        .WithMany("Reports")
                        .HasForeignKey("SenderId");

                    b.HasOne("Pavilyon.Domain.Stage", "Stage")
                        .WithMany("Reports")
                        .HasForeignKey("StageId");

                    b.Navigation("Sender");

                    b.Navigation("Stage");
                });

            modelBuilder.Entity("Pavilyon.Domain.Stage", b =>
                {
                    b.HasOne("Pavilyon.Domain.Project", "Project")
                        .WithMany("Stages")
                        .HasForeignKey("ProjectId");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("ProjectMemberStage", b =>
                {
                    b.HasOne("Pavilyon.Domain.ProjectMember", null)
                        .WithMany()
                        .HasForeignKey("ProjectMembersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pavilyon.Domain.Stage", null)
                        .WithMany()
                        .HasForeignKey("StagesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjectTag", b =>
                {
                    b.HasOne("Pavilyon.Domain.Project", null)
                        .WithMany()
                        .HasForeignKey("ProjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pavilyon.Domain.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Pavilyon.Domain.Project", b =>
                {
                    b.Navigation("Attachments");

                    b.Navigation("Stages");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("Pavilyon.Domain.ProjectMember", b =>
                {
                    b.Navigation("Reports");
                });

            modelBuilder.Entity("Pavilyon.Domain.Stage", b =>
                {
                    b.Navigation("Reports");
                });

            modelBuilder.Entity("Pavilyon.Domain.User", b =>
                {
                    b.Navigation("ProjectMembers");
                });
#pragma warning restore 612, 618
        }
    }
}
