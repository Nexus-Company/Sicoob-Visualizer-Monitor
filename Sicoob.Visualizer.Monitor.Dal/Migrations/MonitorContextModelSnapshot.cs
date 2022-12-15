﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sicoob.Visualizer.Monitor.Dal;

#nullable disable

namespace Sicoob.Visualizer.Monitor.Dal.Migrations
{
    [DbContext(typeof(MonitorContext))]
    partial class MonitorContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Sicoob.Visualizer.Monitor.Dal.Models.Account", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(320)
                        .HasColumnType("nvarchar(320)");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(320)
                        .HasColumnType("nvarchar(320)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(320)
                        .HasColumnType("nvarchar(320)");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Sicoob.Visualizer.Monitor.Dal.Models.Activity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Target")
                        .IsRequired()
                        .HasColumnType("nvarchar(320)");

                    b.Property<byte>("Type")
                        .HasColumnType("tinyint");

                    b.Property<string>("User")
                        .IsRequired()
                        .HasColumnType("nvarchar(320)");

                    b.HasKey("Id");

                    b.HasIndex("Date");

                    b.HasIndex("User");

                    b.HasIndex("Target", "Type", "Date");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("Sicoob.Visualizer.Monitor.Dal.Models.GraphAuthentication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AccessToken")
                        .IsRequired()
                        .HasMaxLength(2500)
                        .HasColumnType("nvarchar(2500)");

                    b.Property<string>("Account")
                        .IsRequired()
                        .HasColumnType("nvarchar(320)");

                    b.Property<DateTime>("RefreshIn")
                        .HasColumnType("datetime2");

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasMaxLength(2500)
                        .HasColumnType("nvarchar(2500)");

                    b.Property<string>("TokenType")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<byte>("Type")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("Account");

                    b.ToTable("Authentications");
                });

            modelBuilder.Entity("Sicoob.Visualizer.Monitor.Dal.Models.Item", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(320)
                        .HasColumnType("nvarchar(320)");

                    b.Property<string>("Directory")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(2147483647)
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("None");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WebUrl")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Sicoob.Visualizer.Monitor.Dal.Models.Activity", b =>
                {
                    b.HasOne("Sicoob.Visualizer.Monitor.Dal.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("Target")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sicoob.Visualizer.Monitor.Dal.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("User")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("Sicoob.Visualizer.Monitor.Dal.Models.GraphAuthentication", b =>
                {
                    b.HasOne("Sicoob.Visualizer.Monitor.Dal.Models.Account", "AccountNavigation")
                        .WithMany()
                        .HasForeignKey("Account")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccountNavigation");
                });
#pragma warning restore 612, 618
        }
    }
}
