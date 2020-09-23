﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VariantTypesGenerics.Final.DbAccess;

namespace VariantTypesGenerics.Final.Migrations
{
    [DbContext(typeof(EmployeeDb))]
    partial class EmployeeDbModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6");

            modelBuilder.Entity("VariantTypesGenerics.Final.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}