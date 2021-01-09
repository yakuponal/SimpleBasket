﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimpleBasket.Persistence;

namespace SimpleBasket.Persistence.Migrations
{
    [DbContext(typeof(SimpleBasketDbContext))]
    [Migration("20210109021837_SeedData")]
    partial class SeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:Collation", "Turkish_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("SimpleBasket.Domain.Entities.Basket", b =>
                {
                    b.Property<int>("BasketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("ProductDetailId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("BasketId");

                    b.HasIndex(new[] { "CustomerId" }, "fkIdx_110");

                    b.HasIndex(new[] { "ProductDetailId" }, "fkIdx_136");

                    b.ToTable("Basket");
                });

            modelBuilder.Entity("SimpleBasket.Domain.Entities.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("SimpleBasket.Domain.Entities.Option", b =>
                {
                    b.Property<int>("OptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("OptionGroupId")
                        .HasColumnType("int");

                    b.Property<string>("OptionName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("OptionId");

                    b.HasIndex(new[] { "OptionGroupId" }, "fkIdx_52");

                    b.ToTable("Option");
                });

            modelBuilder.Entity("SimpleBasket.Domain.Entities.OptionGroup", b =>
                {
                    b.Property<int>("OptionGroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("OptionGroupName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("OptionGroupId");

                    b.ToTable("OptionGroup");
                });

            modelBuilder.Entity("SimpleBasket.Domain.Entities.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ProductId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("SimpleBasket.Domain.Entities.ProductDetail", b =>
                {
                    b.Property<int>("ProductDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductDetailName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("ProductDetailId");

                    b.HasIndex(new[] { "ProductId" }, "fkIdx_130");

                    b.ToTable("ProductDetail");
                });

            modelBuilder.Entity("SimpleBasket.Domain.Entities.ProductOption", b =>
                {
                    b.Property<int>("ProductOptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("OptionId")
                        .HasColumnType("int");

                    b.Property<int>("ProductDetailId")
                        .HasColumnType("int");

                    b.HasKey("ProductOptionId");

                    b.HasIndex(new[] { "ProductDetailId" }, "fkIdx_133");

                    b.HasIndex(new[] { "OptionId" }, "fkIdx_58");

                    b.ToTable("ProductOption");
                });

            modelBuilder.Entity("SimpleBasket.Domain.Entities.Basket", b =>
                {
                    b.HasOne("SimpleBasket.Domain.Entities.Customer", "Customer")
                        .WithMany("Baskets")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK_109")
                        .IsRequired();

                    b.HasOne("SimpleBasket.Domain.Entities.ProductDetail", "ProductDetail")
                        .WithMany("Baskets")
                        .HasForeignKey("ProductDetailId")
                        .HasConstraintName("FK_135")
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("ProductDetail");
                });

            modelBuilder.Entity("SimpleBasket.Domain.Entities.Option", b =>
                {
                    b.HasOne("SimpleBasket.Domain.Entities.OptionGroup", "OptionGroup")
                        .WithMany("Options")
                        .HasForeignKey("OptionGroupId")
                        .HasConstraintName("FK_51")
                        .IsRequired();

                    b.Navigation("OptionGroup");
                });

            modelBuilder.Entity("SimpleBasket.Domain.Entities.ProductDetail", b =>
                {
                    b.HasOne("SimpleBasket.Domain.Entities.Product", "Product")
                        .WithMany("ProductDetails")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK_129")
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("SimpleBasket.Domain.Entities.ProductOption", b =>
                {
                    b.HasOne("SimpleBasket.Domain.Entities.Option", "Option")
                        .WithMany("ProductOptions")
                        .HasForeignKey("OptionId")
                        .HasConstraintName("FK_57")
                        .IsRequired();

                    b.HasOne("SimpleBasket.Domain.Entities.ProductDetail", "ProductDetail")
                        .WithMany("ProductOptions")
                        .HasForeignKey("ProductDetailId")
                        .HasConstraintName("FK_132")
                        .IsRequired();

                    b.Navigation("Option");

                    b.Navigation("ProductDetail");
                });

            modelBuilder.Entity("SimpleBasket.Domain.Entities.Customer", b =>
                {
                    b.Navigation("Baskets");
                });

            modelBuilder.Entity("SimpleBasket.Domain.Entities.Option", b =>
                {
                    b.Navigation("ProductOptions");
                });

            modelBuilder.Entity("SimpleBasket.Domain.Entities.OptionGroup", b =>
                {
                    b.Navigation("Options");
                });

            modelBuilder.Entity("SimpleBasket.Domain.Entities.Product", b =>
                {
                    b.Navigation("ProductDetails");
                });

            modelBuilder.Entity("SimpleBasket.Domain.Entities.ProductDetail", b =>
                {
                    b.Navigation("Baskets");

                    b.Navigation("ProductOptions");
                });
#pragma warning restore 612, 618
        }
    }
}