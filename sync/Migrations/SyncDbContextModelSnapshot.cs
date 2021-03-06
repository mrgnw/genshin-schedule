﻿// <auto-generated />
using System;
using GenshinSchedule.SyncServer.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace GenshinSchedule.SyncServer.Migrations
{
    [DbContext(typeof(SyncDbContext))]
    partial class SyncDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.0-rc.2.20475.6");

            modelBuilder.Entity("GenshinSchedule.SyncServer.Database.DbUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<byte[]>("Password")
                        .HasColumnType("bytea");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.Property<int?>("WebDataId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.HasIndex("WebDataId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GenshinSchedule.SyncServer.Database.DbWebData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Data")
                        .HasColumnType("text");

                    b.Property<Guid>("Token")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("Token")
                        .IsUnique();

                    b.ToTable("WebData");
                });

            modelBuilder.Entity("GenshinSchedule.SyncServer.Database.DbUser", b =>
                {
                    b.HasOne("GenshinSchedule.SyncServer.Database.DbWebData", "WebData")
                        .WithMany()
                        .HasForeignKey("WebDataId");

                    b.Navigation("WebData");
                });
#pragma warning restore 612, 618
        }
    }
}
