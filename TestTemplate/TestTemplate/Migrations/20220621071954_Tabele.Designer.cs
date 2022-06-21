﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestTemplate.Models;

namespace TestTemplate.Migrations
{
    [DbContext(typeof(MainDbContext))]
    [Migration("20220621071954_Tabele")]
    partial class Tabele
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TestTemplate.Models.File", b =>
                {
                    b.Property<int>("TeamID")
                        .HasColumnType("int");

                    b.Property<string>("FileExtention")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<int>("FileID")
                        .HasColumnType("int");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("FileSize")
                        .HasColumnType("int");

                    b.HasKey("TeamID");

                    b.ToTable("File");
                });

            modelBuilder.Entity("TestTemplate.Models.Member", b =>
                {
                    b.Property<int>("MemberID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MemberName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("MemberNickName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("MemberSurname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("OrganisationID")
                        .HasColumnType("int");

                    b.HasKey("MemberID");

                    b.HasIndex("OrganisationID");

                    b.ToTable("Member");
                });

            modelBuilder.Entity("TestTemplate.Models.Membership", b =>
                {
                    b.Property<int?>("TeamID")
                        .HasColumnType("int");

                    b.Property<int?>("MemberID")
                        .HasColumnType("int");

                    b.Property<DateTime>("MembershipDate")
                        .HasColumnType("datetime2");

                    b.HasKey("TeamID");

                    b.HasIndex("MemberID");

                    b.ToTable("Membership");
                });

            modelBuilder.Entity("TestTemplate.Models.Organisation", b =>
                {
                    b.Property<int>("OrganisationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("OrganisationDomain")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("OrganisationName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("OrganisationID");

                    b.ToTable("Organisation");
                });

            modelBuilder.Entity("TestTemplate.Models.Team", b =>
                {
                    b.Property<int>("TeamID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OrganisationID")
                        .HasColumnType("int");

                    b.Property<string>("TeamDescription")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("TeamID");

                    b.HasIndex("OrganisationID");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("TestTemplate.Models.File", b =>
                {
                    b.HasOne("TestTemplate.Models.Team", "Team")
                        .WithMany("File")
                        .HasForeignKey("TeamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("TestTemplate.Models.Member", b =>
                {
                    b.HasOne("TestTemplate.Models.Organisation", "Organisation")
                        .WithMany("Member")
                        .HasForeignKey("OrganisationID")
                        .IsRequired();

                    b.Navigation("Organisation");
                });

            modelBuilder.Entity("TestTemplate.Models.Membership", b =>
                {
                    b.HasOne("TestTemplate.Models.Member", "Member")
                        .WithMany("Membership")
                        .HasForeignKey("MemberID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("TestTemplate.Models.Team", "Team")
                        .WithMany("Membership")
                        .HasForeignKey("TeamID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Member");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("TestTemplate.Models.Team", b =>
                {
                    b.HasOne("TestTemplate.Models.Organisation", "Organisation")
                        .WithMany("Team")
                        .HasForeignKey("OrganisationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organisation");
                });

            modelBuilder.Entity("TestTemplate.Models.Member", b =>
                {
                    b.Navigation("Membership");
                });

            modelBuilder.Entity("TestTemplate.Models.Organisation", b =>
                {
                    b.Navigation("Member");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("TestTemplate.Models.Team", b =>
                {
                    b.Navigation("File");

                    b.Navigation("Membership");
                });
#pragma warning restore 612, 618
        }
    }
}
