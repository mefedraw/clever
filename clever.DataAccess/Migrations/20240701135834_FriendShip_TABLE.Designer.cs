﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using clever.DataAccess;

#nullable disable

namespace clever.DataAccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240701135834_FriendShip_TABLE")]
    partial class FriendShip_TABLE
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("clever.Core.Models.FriendShip", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("FriendId")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<bool>("FriendRequestAccepted")
                        .HasColumnType("boolean");

                    b.Property<DateOnly>("FriendsDate")
                        .HasColumnType("date");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.HasKey("Id");

                    b.ToTable("DbFriendships");
                });

            modelBuilder.Entity("clever.Core.Models.TasksInfo", b =>
                {
                    b.Property<short>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<short>("TaskId"));

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Profit")
                        .HasColumnType("integer");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<decimal>("Workload")
                        .HasColumnType("numeric(20,0)");

                    b.HasKey("TaskId");

                    b.ToTable("DbTasksInfo");
                });

            modelBuilder.Entity("clever.Core.Models.UserAuth", b =>
                {
                    b.Property<string>("TgId")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<DateOnly>("AuthDate")
                        .HasColumnType("date");

                    b.Property<string>("TgUsername")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("TgId");

                    b.ToTable("DbUserAuth");
                });

            modelBuilder.Entity("clever.Core.Models.UserPoints", b =>
                {
                    b.Property<string>("TgId")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<decimal>("Points")
                        .HasColumnType("numeric(20,0)");

                    b.HasKey("TgId");

                    b.ToTable("DbPoints");
                });

            modelBuilder.Entity("clever.Core.Models.UserQuests", b =>
                {
                    b.Property<string>("TgId")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<int>("Completed")
                        .HasColumnType("integer");

                    b.HasKey("TgId");

                    b.ToTable("DbQuests");
                });

            modelBuilder.Entity("clever.Core.Models.UserTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("boolean");

                    b.Property<short>("TaskId")
                        .HasColumnType("smallint");

                    b.Property<string>("TgId")
                        .IsRequired()
                        .HasColumnType("character varying(30)");

                    b.HasKey("Id");

                    b.HasIndex("TaskId");

                    b.HasIndex("TgId");

                    b.ToTable("DbUserTask");
                });

            modelBuilder.Entity("clever.Core.Models.UserPoints", b =>
                {
                    b.HasOne("clever.Core.Models.UserAuth", "UserAuth")
                        .WithMany()
                        .HasForeignKey("TgId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserAuth");
                });

            modelBuilder.Entity("clever.Core.Models.UserQuests", b =>
                {
                    b.HasOne("clever.Core.Models.UserAuth", "UserAuth")
                        .WithMany()
                        .HasForeignKey("TgId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserAuth");
                });

            modelBuilder.Entity("clever.Core.Models.UserTask", b =>
                {
                    b.HasOne("clever.Core.Models.TasksInfo", "TasksInfo")
                        .WithMany()
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("clever.Core.Models.UserAuth", "UserAuth")
                        .WithMany()
                        .HasForeignKey("TgId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TasksInfo");

                    b.Navigation("UserAuth");
                });
#pragma warning restore 612, 618
        }
    }
}
