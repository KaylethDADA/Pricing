﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Pricing.Infrastructure.Context;

#nullable disable

namespace Pricing.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240624161409_TestProductPrices")]
    partial class TestProductPrices
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Pricing.Domain.Entities.AveragePrice", b =>
                {
                    b.Property<DateTime>("DataCreate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CityId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.HasKey("DataCreate", "CityId");

                    b.HasIndex("CityId");

                    b.ToTable("AveragePrices");
                });

            modelBuilder.Entity("Pricing.Domain.Entities.City", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DataCreate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("ParentCityId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ParentCityId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Pricing.Domain.Entities.CityOfUser", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CityId")
                        .HasColumnType("uuid");

                    b.HasKey("UserId", "CityId");

                    b.HasIndex("CityId");

                    b.ToTable("CityOfUsers");
                });

            modelBuilder.Entity("Pricing.Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategorId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DataCreate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CategorId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Pricing.Domain.Entities.ProductCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DataCreate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("ParentCategoryId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("ProductCategory");
                });

            modelBuilder.Entity("Pricing.Domain.Entities.Shop", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("CityId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DataCreate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Shops");
                });

            modelBuilder.Entity("Pricing.Domain.Entities.ShopOfProduct", b =>
                {
                    b.Property<Guid>("ShopId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.HasKey("ShopId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("ShopOfProducts");
                });

            modelBuilder.Entity("Pricing.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DataCreate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Pricing.Domain.Entities.AveragePrice", b =>
                {
                    b.HasOne("Pricing.Domain.Entities.City", "City")
                        .WithMany("AveragePrices")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("Pricing.Domain.Entities.City", b =>
                {
                    b.HasOne("Pricing.Domain.Entities.City", "ParentCity")
                        .WithMany("Region")
                        .HasForeignKey("ParentCityId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("ParentCity");
                });

            modelBuilder.Entity("Pricing.Domain.Entities.CityOfUser", b =>
                {
                    b.HasOne("Pricing.Domain.Entities.City", "City")
                        .WithMany("Users")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pricing.Domain.Entities.User", "User")
                        .WithMany("Citys")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Pricing.Domain.Entities.Product", b =>
                {
                    b.HasOne("Pricing.Domain.Entities.ProductCategory", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsMany("Pricing.Domain.Entities.PriceProduct", "Prices", b1 =>
                        {
                            b1.Property<Guid>("ProductId")
                                .HasColumnType("uuid");

                            b1.Property<DateTime>("DateCreated")
                                .HasColumnType("timestamp with time zone")
                                .HasColumnName("DateCreated");

                            b1.Property<DateTime>("DataCreate")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<decimal>("Price")
                                .HasColumnType("numeric")
                                .HasColumnName("Price");

                            b1.Property<Guid>("ProductId1")
                                .HasColumnType("uuid");

                            b1.HasKey("ProductId", "DateCreated");

                            b1.HasIndex("ProductId1");

                            b1.ToTable("PriceProducts");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");

                            b1.HasOne("Pricing.Domain.Entities.Product", "Product")
                                .WithMany()
                                .HasForeignKey("ProductId1")
                                .OnDelete(DeleteBehavior.Cascade)
                                .IsRequired();

                            b1.Navigation("Product");
                        });

                    b.Navigation("Category");

                    b.Navigation("Prices");
                });

            modelBuilder.Entity("Pricing.Domain.Entities.ProductCategory", b =>
                {
                    b.HasOne("Pricing.Domain.Entities.ProductCategory", "ParentCategory")
                        .WithMany("ChildCategories")
                        .HasForeignKey("ParentCategoryId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("Pricing.Domain.Entities.Shop", b =>
                {
                    b.HasOne("Pricing.Domain.Entities.City", "City")
                        .WithMany("Shop")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("Pricing.Domain.Entities.ShopOfProduct", b =>
                {
                    b.HasOne("Pricing.Domain.Entities.Product", "Product")
                        .WithMany("Shops")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pricing.Domain.Entities.Shop", "Shop")
                        .WithMany("Products")
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Shop");
                });

            modelBuilder.Entity("Pricing.Domain.Entities.User", b =>
                {
                    b.OwnsOne("Pricing.Domain.ValueObjects.FullName", "FullName", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uuid");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("MiddleName")
                                .HasColumnType("text");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("FullName")
                        .IsRequired();
                });

            modelBuilder.Entity("Pricing.Domain.Entities.City", b =>
                {
                    b.Navigation("AveragePrices");

                    b.Navigation("Region");

                    b.Navigation("Shop");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Pricing.Domain.Entities.Product", b =>
                {
                    b.Navigation("Shops");
                });

            modelBuilder.Entity("Pricing.Domain.Entities.ProductCategory", b =>
                {
                    b.Navigation("ChildCategories");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("Pricing.Domain.Entities.Shop", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Pricing.Domain.Entities.User", b =>
                {
                    b.Navigation("Citys");
                });
#pragma warning restore 612, 618
        }
    }
}
