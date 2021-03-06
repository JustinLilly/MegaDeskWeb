﻿// <auto-generated />
using System;
using MegaDeskWeb.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MegaDeskWeb.Migrations
{
    [DbContext(typeof(MegaDeskWebContext))]
    partial class MegaDeskWebContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MegaDeskWeb.Models.Delivery", b =>
                {
                    b.Property<int>("DeliveryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DeliveryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PriceBetween1000And2000")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PriceOver2000")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PriceUnder1000")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("DeliveryId");

                    b.ToTable("Delivery");
                });

            modelBuilder.Entity("MegaDeskWeb.Models.Desk", b =>
                {
                    b.Property<int>("DeskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Depth")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("DesktopMaterialId")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfDrawers")
                        .HasColumnType("int");

                    b.Property<decimal>("Width")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("DeskId");

                    b.HasIndex("DesktopMaterialId");

                    b.ToTable("Desk");
                });

            modelBuilder.Entity("MegaDeskWeb.Models.DeskQuote", b =>
                {
                    b.Property<int>("DeskQuoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DeliveryTypeId")
                        .HasColumnType("int");

                    b.Property<int>("DeskId")
                        .HasColumnType("int");

                    b.Property<DateTime>("QuoteDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("QuotePrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("DeskQuoteId");

                    b.HasIndex("DeliveryTypeId");

                    b.HasIndex("DeskId");

                    b.ToTable("DeskQuote");
                });

            modelBuilder.Entity("MegaDeskWeb.Models.DesktopMaterial", b =>
                {
                    b.Property<int>("DesktopMaterialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("DesktopMaterialName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DesktopMaterialId");

                    b.ToTable("DesktopMaterial");
                });

            modelBuilder.Entity("MegaDeskWeb.Models.Desk", b =>
                {
                    b.HasOne("MegaDeskWeb.Models.DesktopMaterial", "DesktopMaterial")
                        .WithMany()
                        .HasForeignKey("DesktopMaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MegaDeskWeb.Models.DeskQuote", b =>
                {
                    b.HasOne("MegaDeskWeb.Models.Delivery", "DeliveryType")
                        .WithMany()
                        .HasForeignKey("DeliveryTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MegaDeskWeb.Models.Desk", "Desk")
                        .WithMany()
                        .HasForeignKey("DeskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
