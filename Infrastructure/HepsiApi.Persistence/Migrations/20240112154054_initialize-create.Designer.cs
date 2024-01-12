﻿// <auto-generated />
using System;
using HepsiApi.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HepsiApi.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240112154054_initialize-create")]
    partial class initializecreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CategoryProduct", b =>
                {
                    b.Property<int>("CategoriesID")
                        .HasColumnType("int");

                    b.Property<int>("ProductsID")
                        .HasColumnType("int");

                    b.HasKey("CategoriesID", "ProductsID");

                    b.HasIndex("ProductsID");

                    b.ToTable("CategoryProduct");
                });

            modelBuilder.Entity("HepsiApi.Domain.Entities.Brand", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("ID");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CreatedDate = new DateTime(2024, 1, 12, 18, 40, 54, 11, DateTimeKind.Local).AddTicks(9225),
                            IsDeleted = false,
                            Name = "Sports"
                        },
                        new
                        {
                            ID = 2,
                            CreatedDate = new DateTime(2024, 1, 12, 18, 40, 54, 11, DateTimeKind.Local).AddTicks(9283),
                            IsDeleted = false,
                            Name = "Electronics, Automotive & Beauty"
                        },
                        new
                        {
                            ID = 3,
                            CreatedDate = new DateTime(2024, 1, 12, 18, 40, 54, 11, DateTimeKind.Local).AddTicks(9298),
                            IsDeleted = true,
                            Name = "Beauty, Health & Beauty"
                        });
                });

            modelBuilder.Entity("HepsiApi.Domain.Entities.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ParentID")
                        .HasColumnType("int");

                    b.Property<int>("Priorty")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CreatedDate = new DateTime(2024, 1, 12, 18, 40, 54, 12, DateTimeKind.Local).AddTicks(2761),
                            IsDeleted = false,
                            Name = "Elektrik",
                            ParentID = 0,
                            Priorty = 1
                        },
                        new
                        {
                            ID = 2,
                            CreatedDate = new DateTime(2024, 1, 12, 18, 40, 54, 12, DateTimeKind.Local).AddTicks(2762),
                            IsDeleted = false,
                            Name = "Moda",
                            ParentID = 0,
                            Priorty = 2
                        },
                        new
                        {
                            ID = 3,
                            CreatedDate = new DateTime(2024, 1, 12, 18, 40, 54, 12, DateTimeKind.Local).AddTicks(2764),
                            IsDeleted = false,
                            Name = "Bilgisayar",
                            ParentID = 1,
                            Priorty = 1
                        },
                        new
                        {
                            ID = 4,
                            CreatedDate = new DateTime(2024, 1, 12, 18, 40, 54, 12, DateTimeKind.Local).AddTicks(2765),
                            IsDeleted = false,
                            Name = "Kadın",
                            ParentID = 2,
                            Priorty = 1
                        });
                });

            modelBuilder.Entity("HepsiApi.Domain.Entities.Detail", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Details");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CategoryID = 1,
                            CreatedDate = new DateTime(2024, 1, 12, 18, 40, 54, 15, DateTimeKind.Local).AddTicks(1425),
                            Description = "Sevindi enim sunt sıradanlıktan consequuntur.",
                            IsDeleted = false,
                            Title = "Sandalye."
                        },
                        new
                        {
                            ID = 2,
                            CategoryID = 3,
                            CreatedDate = new DateTime(2024, 1, 12, 18, 40, 54, 15, DateTimeKind.Local).AddTicks(1496),
                            Description = "Eve dolor karşıdakine qui bundan.",
                            IsDeleted = true,
                            Title = "Ve mutlu."
                        },
                        new
                        {
                            ID = 3,
                            CategoryID = 4,
                            CreatedDate = new DateTime(2024, 1, 12, 18, 40, 54, 15, DateTimeKind.Local).AddTicks(1529),
                            Description = "Çorba ut aut minima exercitationem.",
                            IsDeleted = false,
                            Title = "Aut."
                        });
                });

            modelBuilder.Entity("HepsiApi.Domain.Entities.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("BrandID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("BrandID");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            BrandID = 1,
                            CreatedDate = new DateTime(2024, 1, 12, 18, 40, 54, 17, DateTimeKind.Local).AddTicks(4535),
                            Description = "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support",
                            Discount = 25.490218742405200m,
                            IsDeleted = false,
                            Price = 48.35m,
                            Title = "Sleek Rubber Tuna"
                        },
                        new
                        {
                            ID = 2,
                            BrandID = 3,
                            CreatedDate = new DateTime(2024, 1, 12, 18, 40, 54, 17, DateTimeKind.Local).AddTicks(4559),
                            Description = "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support",
                            Discount = 28.829056385503800m,
                            IsDeleted = false,
                            Price = 423.34m,
                            Title = "Generic Plastic Car"
                        });
                });

            modelBuilder.Entity("CategoryProduct", b =>
                {
                    b.HasOne("HepsiApi.Domain.Entities.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HepsiApi.Domain.Entities.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HepsiApi.Domain.Entities.Detail", b =>
                {
                    b.HasOne("HepsiApi.Domain.Entities.Category", "Category")
                        .WithMany("Details")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("HepsiApi.Domain.Entities.Product", b =>
                {
                    b.HasOne("HepsiApi.Domain.Entities.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("HepsiApi.Domain.Entities.Category", b =>
                {
                    b.Navigation("Details");
                });
#pragma warning restore 612, 618
        }
    }
}