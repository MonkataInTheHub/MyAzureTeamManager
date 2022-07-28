﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyAzureTeamManager;

#nullable disable

namespace MyAzureTeamManager.Migrations
{
    [DbContext(typeof(MyAzureTeamManagerDbContext))]
    [Migration("20220728123529_ExtendedDb")]
    partial class ExtendedDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MyAzureTeamManager.Models.Board", b =>
                {
                    b.Property<int>("BoardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BoardId"), 1L, 1);

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("BoardId");

                    b.HasIndex("TeamId");

                    b.ToTable("Boards");
                });

            modelBuilder.Entity("MyAzureTeamManager.Models.Bug", b =>
                {
                    b.Property<int>("BugId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BugId"), 1L, 1);

                    b.Property<int>("BoardId")
                        .HasColumnType("int");

                    b.Property<int>("BugStatus")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("History")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<int>("Severity")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BugId");

                    b.HasIndex("BoardId");

                    b.ToTable("Bugs");
                });

            modelBuilder.Entity("MyAzureTeamManager.Models.Feedback", b =>
                {
                    b.Property<int>("FeedbackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FeedbackId"), 1L, 1);

                    b.Property<int?>("BoardId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FeedbackStatus")
                        .HasColumnType("int");

                    b.Property<string>("History")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FeedbackId");

                    b.HasIndex("BoardId");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("MyAzureTeamManager.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonId"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("PersonId");

                    b.HasIndex("TeamId");

                    b.ToTable("People");
                });

            modelBuilder.Entity("MyAzureTeamManager.Models.Task", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaskId"), 1L, 1);

                    b.Property<int>("BoardId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("History")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<int>("TaskStatus")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TaskId");

                    b.HasIndex("BoardId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("MyAzureTeamManager.Models.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeamId"), 1L, 1);

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeamId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("MyAzureTeamManager.Models.Board", b =>
                {
                    b.HasOne("MyAzureTeamManager.Models.Team", null)
                        .WithMany("Boards")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyAzureTeamManager.Models.Bug", b =>
                {
                    b.HasOne("MyAzureTeamManager.Models.Board", null)
                        .WithMany("Bugs")
                        .HasForeignKey("BoardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyAzureTeamManager.Models.Feedback", b =>
                {
                    b.HasOne("MyAzureTeamManager.Models.Board", null)
                        .WithMany("Feedbacks")
                        .HasForeignKey("BoardId");
                });

            modelBuilder.Entity("MyAzureTeamManager.Models.Person", b =>
                {
                    b.HasOne("MyAzureTeamManager.Models.Team", null)
                        .WithMany("Members")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyAzureTeamManager.Models.Task", b =>
                {
                    b.HasOne("MyAzureTeamManager.Models.Board", null)
                        .WithMany("Tasks")
                        .HasForeignKey("BoardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyAzureTeamManager.Models.Board", b =>
                {
                    b.Navigation("Bugs");

                    b.Navigation("Feedbacks");

                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("MyAzureTeamManager.Models.Team", b =>
                {
                    b.Navigation("Boards");

                    b.Navigation("Members");
                });
#pragma warning restore 612, 618
        }
    }
}