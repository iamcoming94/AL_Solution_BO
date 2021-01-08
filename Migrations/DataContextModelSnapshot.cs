﻿// <auto-generated />
using System;
using ArcherLogic_Salon_Solution.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ArcherLogic_Salon_Solution.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("ArcherLogic_Salon_Solution.DAL.MediaDAL", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("NAME")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("media");
                });

            modelBuilder.Entity("ArcherLogic_Salon_Solution.DAL.PhotoDAL", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<byte[]>("DATA")
                        .HasColumnType("bytea");

                    b.Property<string>("NAME")
                        .HasColumnType("text");

                    b.Property<int>("USER_ID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.ToTable("photo");
                });

            modelBuilder.Entity("ArcherLogic_Salon_Solution.DAL.UserDAL", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("ADDRESS")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CONTACT_NUMBER")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DATE_OF_BIRTH")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("GENDER")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("HOW_DID_YOU_FIND_US")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("IS_ACTIVE")
                        .HasColumnType("integer");

                    b.Property<string>("USERNAME")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("user");
                });
#pragma warning restore 612, 618
        }
    }
}