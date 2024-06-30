﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using clever.DataAccess;

#nullable disable

namespace clever.DataAccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

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
#pragma warning restore 612, 618
        }
    }
}
