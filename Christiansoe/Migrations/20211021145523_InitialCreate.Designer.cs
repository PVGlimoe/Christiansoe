﻿// <auto-generated />
using System;
using Christiansoe.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Christiansoe.Migrations
{
    [DbContext(typeof(ChristiansoeContext))]
    [Migration("20211021145523_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Christiansoe.Models.BingoBoard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MapId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MapId");

                    b.ToTable("BingoBoard");
                });

            modelBuilder.Entity("Christiansoe.Models.Field", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BingoBoardId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PictureUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SoundUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BingoBoardId");

                    b.ToTable("Field");
                });

            modelBuilder.Entity("Christiansoe.Models.Map", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Map");
                });

            modelBuilder.Entity("Christiansoe.Models.Route", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BingoBoardId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HikingTime")
                        .HasColumnType("int");

                    b.Property<double>("Length")
                        .HasColumnType("float");

                    b.Property<int?>("MapId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Theme")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BingoBoardId");

                    b.HasIndex("MapId");

                    b.ToTable("Route");
                });

            modelBuilder.Entity("Christiansoe.Models.BingoBoard", b =>
                {
                    b.HasOne("Christiansoe.Models.Map", "Map")
                        .WithMany()
                        .HasForeignKey("MapId");

                    b.Navigation("Map");
                });

            modelBuilder.Entity("Christiansoe.Models.Field", b =>
                {
                    b.HasOne("Christiansoe.Models.BingoBoard", null)
                        .WithMany("Fields")
                        .HasForeignKey("BingoBoardId");
                });

            modelBuilder.Entity("Christiansoe.Models.Route", b =>
                {
                    b.HasOne("Christiansoe.Models.BingoBoard", "BingoBoard")
                        .WithMany()
                        .HasForeignKey("BingoBoardId");

                    b.HasOne("Christiansoe.Models.Map", "Map")
                        .WithMany()
                        .HasForeignKey("MapId");

                    b.Navigation("BingoBoard");

                    b.Navigation("Map");
                });

            modelBuilder.Entity("Christiansoe.Models.BingoBoard", b =>
                {
                    b.Navigation("Fields");
                });
#pragma warning restore 612, 618
        }
    }
}
