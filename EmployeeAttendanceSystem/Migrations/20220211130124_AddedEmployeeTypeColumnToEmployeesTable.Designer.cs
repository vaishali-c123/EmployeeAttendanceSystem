﻿// <auto-generated />
using System;
using EmployeeAttendanceSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmployeeAttendanceSystem.Migrations
{
    [DbContext(typeof(EmployeeAttendanceSystemContext))]
    [Migration("20220211130124_AddedEmployeeTypeColumnToEmployeesTable")]
    partial class AddedEmployeeTypeColumnToEmployeesTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EmployeeAttendanceSystem.Models.Admin", b =>
                {
                    b.Property<string>("AdminId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("AdminPassword")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("AdminUsername")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("AdminId");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("EmployeeAttendanceSystem.Models.Attendance", b =>
                {
                    b.Property<string>("AttendanceId")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("AttendanceDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("AttendanceStatus")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<string>("EmployeeId")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("AttendanceId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Attendances");
                });

            modelBuilder.Entity("EmployeeAttendanceSystem.Models.Employee", b =>
                {
                    b.Property<string>("EmployeeId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("EmployeeContact")
                        .HasMaxLength(10)
                        .HasColumnType("float");

                    b.Property<string>("EmployeeEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeGender")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("EmployeePassword")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("EmployeeType")
                        .HasColumnType("int");

                    b.Property<string>("EmployeeUsername")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("EmployeeAttendanceSystem.Models.Leave", b =>
                {
                    b.Property<string>("LeaveId")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("EmployeeId")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("LeaveApplyDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LeaveEndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LeaveReason")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("LeaveStartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("LeaveId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Leaves");
                });

            modelBuilder.Entity("EmployeeAttendanceSystem.Models.Attendance", b =>
                {
                    b.HasOne("EmployeeAttendanceSystem.Models.Employee", "Employees")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.Navigation("Employees");
                });

            modelBuilder.Entity("EmployeeAttendanceSystem.Models.Leave", b =>
                {
                    b.HasOne("EmployeeAttendanceSystem.Models.Employee", "Employees")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
