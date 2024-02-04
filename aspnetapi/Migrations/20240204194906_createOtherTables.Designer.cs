﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using aspnetapp.DataAccessLayer.DBContexts;

#nullable disable

namespace aspnetapp.Migrations
{
    [DbContext(typeof(PatientDbContext))]
    [Migration("20240204194906_createOtherTables")]
    partial class createOtherTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("aspnetapp.Model.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("City")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValue(new DateTime(2024, 2, 4, 11, 49, 6, 562, DateTimeKind.Local).AddTicks(5970));

                    b.Property<DateTime>("Dob")
                        .HasMaxLength(15)
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("LastName")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("MiddleName")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Ssn")
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<string>("State")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Zip")
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.HasKey("Id");

                    b.ToTable("patient", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "101 A Str",
                            City = "Somewhere",
                            CreatedAt = new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Dob = new DateTime(1970, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "aaa@b.com",
                            FirstName = "David",
                            LastName = "Mike",
                            MiddleName = "A",
                            Ssn = "123456789",
                            State = "CA",
                            Zip = "94000"
                        },
                        new
                        {
                            Id = 2,
                            Address = "101 A Str",
                            City = "Somewhere",
                            CreatedAt = new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Dob = new DateTime(1972, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "bbbb@b.com",
                            FirstName = "Steve",
                            LastName = "Warner",
                            MiddleName = "B",
                            Ssn = "123456788",
                            State = "CA",
                            Zip = "94001"
                        });
                });

            modelBuilder.Entity("aspnetapp.Model.PatientLabResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Attachments")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValue(new DateTime(2024, 2, 4, 11, 49, 6, 564, DateTimeKind.Local).AddTicks(2100));

                    b.Property<int>("Lab_visit_id")
                        .HasColumnType("int");

                    b.Property<int>("Patient_id")
                        .HasColumnType("int");

                    b.Property<string>("Test_name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Test_observation")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Test_result")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("patient_lab_result", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Attachments = "a certain attachment",
                            CreatedAt = new DateTime(2024, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Lab_visit_id = 1,
                            Patient_id = 1,
                            Test_name = "a certain test name",
                            Test_observation = "a certain test observation",
                            Test_result = "a certain test result"
                        },
                        new
                        {
                            Id = 2,
                            Attachments = "yet antoher certain attachment",
                            CreatedAt = new DateTime(2024, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Lab_visit_id = 2,
                            Patient_id = 2,
                            Test_name = "yet another certain test name",
                            Test_observation = "yet another certain test observation",
                            Test_result = "yet another certain test result"
                        });
                });

            modelBuilder.Entity("aspnetapp.Model.PatientLabVisit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValue(new DateTime(2024, 2, 4, 11, 49, 6, 563, DateTimeKind.Local).AddTicks(1080));

                    b.Property<string>("Lab_name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Lab_test_request")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Patient_id")
                        .HasColumnType("int");

                    b.Property<string>("Result_date")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("patient_lab_visit", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Lab_name = "Test Lab for Mike",
                            Lab_test_request = "Need a test for Mike",
                            Patient_id = 1
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Lab_name = "Test Lab for Steve",
                            Lab_test_request = "Need a test for Steve",
                            Patient_id = 2
                        });
                });

            modelBuilder.Entity("aspnetapp.Model.PatientMedication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValue(new DateTime(2024, 2, 4, 11, 49, 6, 564, DateTimeKind.Local).AddTicks(9000));

                    b.Property<string>("Dosage")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Frequency")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Medicine_name")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<int>("Patient_id")
                        .HasColumnType("int");

                    b.Property<string>("Prescribed_by")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("Prescription_date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Prescription_period")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Visit_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("patient_medicine", (string)null);
                });

            modelBuilder.Entity("aspnetapp.Model.PatientVaccinationData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Administered_by")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValue(new DateTime(2024, 2, 4, 11, 49, 6, 565, DateTimeKind.Local).AddTicks(4090));

                    b.Property<int>("Patient_id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Vaccine_date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Vaccine_name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Vaccine_validity")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("patient_vaccination_data", (string)null);
                });

            modelBuilder.Entity("aspnetapp.Model.PatientVisitHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValue(new DateTime(2024, 2, 4, 11, 49, 6, 563, DateTimeKind.Local).AddTicks(6350));

                    b.Property<string>("Doctor_name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Nurse_name_1")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nurse_name_2")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Patient_id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Visit_date")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("patient_visit_history", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
