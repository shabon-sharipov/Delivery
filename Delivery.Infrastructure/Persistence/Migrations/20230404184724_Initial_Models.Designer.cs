﻿// <auto-generated />
using System;
using Delivery.Infrastructure.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Delivery.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(EFContext))]
    [Migration("20230404184724_Initial_Models")]
    partial class Initial_Models
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Delivery.Domain.Abstract.Category", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(20,0)");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<decimal>("Id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortDescreption")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Category", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("Category");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Delivery.Domain.Model.Merchant", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(20,0)");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<decimal>("Id"));

                    b.Property<string>("IsActive")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("MerchantCategoryId")
                        .HasColumnType("decimal(20,0)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortDiscreption")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MerchantCategoryId");

                    b.ToTable("Merchant", (string)null);
                });

            modelBuilder.Entity("Delivery.Domain.Model.Order", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(20,0)");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<decimal>("Id"));

                    b.Property<string>("AvailableFrom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AvailableTo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("CustomerId")
                        .HasColumnType("decimal(20,0)");

                    b.Property<decimal>("DriverId")
                        .HasColumnType("decimal(20,0)");

                    b.Property<bool>("IsPayment")
                        .HasColumnType("bit");

                    b.Property<int>("OrderStatus")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("SenderId")
                        .HasColumnType("decimal(20,0)");

                    b.Property<string>("ShipAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ShipDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DriverId");

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("Delivery.Domain.Model.Product", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(20,0)");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<decimal>("Id"));

                    b.Property<decimal>("CategoryId")
                        .HasColumnType("decimal(20,0)");

                    b.Property<string>("Discription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<decimal>("MerchantId")
                        .HasColumnType("decimal(20,0)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("MerchantId");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("OrderDetails", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(20,0)");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<decimal>("Id"));

                    b.Property<decimal>("OrderId")
                        .HasColumnType("decimal(20,0)");

                    b.Property<decimal>("ProductId")
                        .HasColumnType("decimal(20,0)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails", (string)null);
                });

            modelBuilder.Entity("Person", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(20,0)");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<decimal>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Person", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("Person");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Delivery.Domain.Model.MerchantCategory", b =>
                {
                    b.HasBaseType("Delivery.Domain.Abstract.Category");

                    b.HasDiscriminator().HasValue("MerchantCategory");
                });

            modelBuilder.Entity("Delivery.Domain.Model.ProductCategory", b =>
                {
                    b.HasBaseType("Delivery.Domain.Abstract.Category");

                    b.HasDiscriminator().HasValue("ProductCategory");
                });

            modelBuilder.Entity("Customer", b =>
                {
                    b.HasBaseType("Person");

                    b.HasDiscriminator().HasValue("Customer");
                });

            modelBuilder.Entity("Delivery.Domain.Model.Driver", b =>
                {
                    b.HasBaseType("Person");

                    b.HasDiscriminator().HasValue("Driver");
                });

            modelBuilder.Entity("Delivery.Domain.Model.Merchant", b =>
                {
                    b.HasOne("Delivery.Domain.Model.MerchantCategory", "MerchantCategory")
                        .WithMany()
                        .HasForeignKey("MerchantCategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("MerchantCategory");
                });

            modelBuilder.Entity("Delivery.Domain.Model.Order", b =>
                {
                    b.HasOne("Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Delivery.Domain.Model.Driver", "Driver")
                        .WithMany()
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Driver");
                });

            modelBuilder.Entity("Delivery.Domain.Model.Product", b =>
                {
                    b.HasOne("Delivery.Domain.Model.ProductCategory", "CategoryProduct")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Delivery.Domain.Model.Merchant", "Merchant")
                        .WithMany("Products")
                        .HasForeignKey("MerchantId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CategoryProduct");

                    b.Navigation("Merchant");
                });

            modelBuilder.Entity("OrderDetails", b =>
                {
                    b.HasOne("Delivery.Domain.Model.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Delivery.Domain.Model.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Delivery.Domain.Model.Merchant", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Delivery.Domain.Model.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
