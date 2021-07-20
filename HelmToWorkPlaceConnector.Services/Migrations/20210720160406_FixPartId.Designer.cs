﻿// <auto-generated />
using System;
using HelmToWorkPlaceConnector.Services.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HelmToWorkPlaceConnector.Services.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210720160406_FixPartId")]
    partial class FixPartId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HelmToWorkPlaceConnector.Services.Models.Requisition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Assset")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Divisionid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("EstCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ExternalNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LineItemCount")
                        .HasColumnType("int");

                    b.Property<decimal>("LinkedItemType")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("LinkedItemid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Priority")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Space")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.ToTable("Requisitions");
                });

            modelBuilder.Entity("HelmToWorkPlaceConnector.Services.Models.RequisitionLine", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Assset")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("EstPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ExternalNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PartCategory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PartDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PartId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PartNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PartUnit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Priority")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("RequisitionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Space")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VendorName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.ToTable("RequisitionLines");
                });

            modelBuilder.Entity("HelmToWorkPlaceConnector.Services.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("HelmToWorkPlaceConnector.Services.Models.Requisition", b =>
                {
                    b.HasOne("HelmToWorkPlaceConnector.Services.Models.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedBy");
                });

            modelBuilder.Entity("HelmToWorkPlaceConnector.Services.Models.RequisitionLine", b =>
                {
                    b.HasOne("HelmToWorkPlaceConnector.Services.Models.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedBy");
                });
#pragma warning restore 612, 618
        }
    }
}
