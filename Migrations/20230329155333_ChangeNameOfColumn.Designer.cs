﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeatherApp2023.Infrastructure.Persistence;

#nullable disable

namespace WeatherApp2023.Migrations
{
    [DbContext(typeof(DatapointContext))]
    [Migration("20230329155333_ChangeNameOfColumn")]
    partial class ChangeNameOfColumn
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WeatherApp2023.BusinessModels.DataPoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Cloud")
                        .HasColumnType("float");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<double>("Temperature")
                        .HasColumnType("float");

                    b.Property<double>("WindSpeed")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("DataPoint", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
