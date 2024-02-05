
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using aspnetapp.Model;
using MySql.EntityFrameworkCore.Extensions;


namespace aspnetapp.DataAccessLayer.DBContexts
{
    public class PatientDbContext : DbContext
    {
        public PatientDbContext(DbContextOptions<PatientDbContext> options)
           : base(options)
        {
        }
        public DbSet<Patient> Patients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // the schema part
            
            modelBuilder.Entity<Patient>().ToTable("patient");
            modelBuilder.Entity<Patient>().HasKey(a => a.Id);
            modelBuilder.Entity<Patient>() .Property(e => e.Id).ForMySQLHasDefaultValue();
            
            modelBuilder.Entity<Patient>().Property(x => x.LastName).HasMaxLength(100);
            modelBuilder.Entity<Patient>().Property(x => x.Address).HasMaxLength(200);
            modelBuilder.Entity<Patient>().Property(x => x.City).HasMaxLength(100);
            modelBuilder.Entity<Patient>().Property(x => x.State).HasMaxLength(50);
            modelBuilder.Entity<Patient>().Property(x => x.Zip).HasMaxLength(15);
            modelBuilder.Entity<Patient>().Property(x => x.FirstName).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Patient>().Property(x => x.MiddleName).HasMaxLength(100);
            modelBuilder.Entity<Patient>().Property(x => x.Email).IsRequired().HasMaxLength(150);
            modelBuilder.Entity<Patient>().Property(x => x.Dob).IsRequired().HasMaxLength(15);
            modelBuilder.Entity<Patient>().Property(x => x.Ssn).HasMaxLength(15);
            modelBuilder.Entity<Patient>().Property(x => x.CreatedAt).IsRequired().HasDefaultValue(DateTime.Now);
           
            modelBuilder.Entity<PatientLabVisit>().ToTable("patient_lab_visit");
            modelBuilder.Entity<PatientLabVisit>().HasKey(a => a.Id);
            modelBuilder.Entity<Patient>() .Property(e => e.Id).ForMySQLHasDefaultValue();
            modelBuilder.Entity<PatientLabVisit>().Property(x => x.Patient_id).IsRequired();
            modelBuilder.Entity<PatientLabVisit>().Property(x => x.Lab_name).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<PatientLabVisit>().Property(x => x.Lab_test_request).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<PatientLabVisit>().Property(x => x.Result_date);
            modelBuilder.Entity<PatientLabVisit>().Property(x => x.CreatedAt).IsRequired().HasDefaultValue(DateTime.Now);
            modelBuilder.Entity<PatientLabVisit>()
                .HasOne(e => e.Patient)
                .WithMany(e => e.PatientLabVisits)
                .HasForeignKey(e => e.Patient_id)
                .HasForeignKey(x => x.Patient_id);
                // .IsRequired()
                // .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PatientVisitHistory>().ToTable("patient_visit_history");
            modelBuilder.Entity<PatientVisitHistory>().HasKey(a => a.Id);
            modelBuilder.Entity<PatientVisitHistory>().Property(x => x.Patient_id).IsRequired();
            modelBuilder.Entity<PatientVisitHistory>().Property(x => x.Doctor_name).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<PatientVisitHistory>().Property(x => x.Nurse_name_1).HasMaxLength(100);
            modelBuilder.Entity<PatientVisitHistory>().Property(x => x.Nurse_name_2).HasMaxLength(100);
            modelBuilder.Entity<PatientVisitHistory>().Property(x => x.Visit_date).IsRequired();
            modelBuilder.Entity<PatientVisitHistory>().Property(x => x.CreatedAt).IsRequired().HasDefaultValue(DateTime.Now);
            modelBuilder.Entity<PatientVisitHistory>()
                .HasOne(e => e.Patient)
                .WithMany(e => e.PatientVisitHistories)
                .HasForeignKey(e => e.Patient_id); 
                // .IsRequired()
                // .OnDelete(DeleteBehavior.Cascade);
            
            
            modelBuilder.Entity<PatientLabResult>().ToTable("patient_lab_result");
            modelBuilder.Entity<PatientLabResult>().HasKey(a => a.Id);
            modelBuilder.Entity<Patient>() .Property(e => e.Id).ForMySQLHasDefaultValue();
            modelBuilder.Entity<PatientLabResult>().Property(x => x.Patient_id).IsRequired();
            modelBuilder.Entity<PatientLabResult>().Property(x => x.Test_name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<PatientLabResult>().Property(x => x.Test_observation).HasMaxLength(200);
            modelBuilder.Entity<PatientLabResult>().Property(x => x.Test_result).HasMaxLength(100);
            modelBuilder.Entity<PatientLabResult>().Property(x => x.CreatedAt).IsRequired().HasDefaultValue(DateTime.Now);
            modelBuilder.Entity<PatientLabResult>()
                .HasOne(e => e.Patient)
                .WithMany(e => e.PatientLabResults)
                .HasForeignKey(e => e.Patient_id);
                // .IsRequired()
                // .OnDelete(DeleteBehavior.Cascade);

            
            
            modelBuilder.Entity<PatientMedication>().ToTable("patient_medicine");
            modelBuilder.Entity<PatientMedication>().HasKey(a => a.Id);
            modelBuilder.Entity<Patient>() .Property(e => e.Id).ForMySQLHasDefaultValue();
            modelBuilder.Entity<PatientMedication>().Property(x => x.Patient_id).IsRequired();
            modelBuilder.Entity<PatientMedication>().Property(x => x.Visit_id);
            modelBuilder.Entity<PatientMedication>().Property(x => x.Medicine_name).HasMaxLength(200);
            modelBuilder.Entity<PatientMedication>().Property(x => x.Dosage).HasMaxLength(100);
            modelBuilder.Entity<PatientMedication>().Property(x => x.Frequency).HasMaxLength(100);
            modelBuilder.Entity<PatientMedication>().Property(x => x.Prescribed_by).HasMaxLength(100);
            modelBuilder.Entity<PatientMedication>().Property(x => x.Prescription_period).HasMaxLength(100);
            modelBuilder.Entity<PatientMedication>().Property(x => x.CreatedAt).IsRequired().HasDefaultValue(DateTime.Now);
            modelBuilder.Entity<PatientMedication>()
                .HasOne(e => e.Patient)
                .WithMany(e => e.PatientMedications)
                .HasForeignKey(e => e.Patient_id);
                // .IsRequired()
                // .OnDelete(DeleteBehavior.Cascade);

            
            modelBuilder.Entity<PatientVaccinationData>().ToTable("patient_vaccination_data");
            modelBuilder.Entity<PatientVaccinationData>().HasKey(a => a.Id);
            modelBuilder.Entity<Patient>() .Property(e => e.Id).ForMySQLHasDefaultValue();
            modelBuilder.Entity<PatientVaccinationData>().Property(x => x.Patient_id).IsRequired();
            modelBuilder.Entity<PatientVaccinationData>().Property(x => x.Vaccine_name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<PatientVaccinationData>().Property(x => x.Vaccine_date).IsRequired();
            modelBuilder.Entity<PatientVaccinationData>().Property(x => x.Vaccine_validity).HasMaxLength(100);
            modelBuilder.Entity<PatientVaccinationData>().Property(x => x.Administered_by).HasMaxLength(100);
            modelBuilder.Entity<PatientVaccinationData>().Property(x => x.CreatedAt).IsRequired().HasDefaultValue(DateTime.Now);
            modelBuilder.Entity<PatientVaccinationData>()
                .HasOne(e => e.Patient)
                .WithMany(e => e.PatientVaccinationDatas)
                .HasForeignKey(e => e.Patient_id);
                // .IsRequired()
                // .OnDelete(DeleteBehavior.Cascade);


            
            // the data part
            
            modelBuilder.Entity<Patient>().HasData(
                new Patient
                {
                    Id = 1,
                    LastName = "Mike",
                    FirstName = "David",
                    MiddleName = "A",
                    Dob = new DateTime(1970, 1, 5),
                    Address = "101 A Str",
                    City = "Somewhere",
                    State = "CA",
                    Zip = "94000",
                    Ssn = "123456789",
                    Email = "aaa@b.com",
                    CreatedAt = new DateTime(2024, 2, 1)
                },
               new Patient
               {
                   Id = 2,
                   LastName = "Warner",
                   FirstName = "Steve",
                   MiddleName = "B",
                   Dob = new DateTime(1972, 3, 12),
                   Address = "101 A Str",
                   City = "Somewhere",
                   State = "CA",
                   Zip = "94001",
                   Ssn = "123456788",
                   Email = "bbbb@b.com",
                   CreatedAt = new DateTime(2024, 2, 1)
               }
               );

            modelBuilder.Entity<PatientLabVisit>().HasData(
                new PatientLabVisit()
                {
                    Id = 1,
                    Lab_name = "Test Lab for Mike",
                    Lab_test_request = "Need a test for Mike",
                    Patient_id = 1,
                    CreatedAt = new DateTime(2024, 2, 4)
                },
                new PatientLabVisit()
                {
                    Id = 2,
                    Lab_name = "Test Lab for Steve",
                    Lab_test_request = "Need a test for Steve",
                    Patient_id = 2,
                    CreatedAt = new DateTime(2024, 2, 4)
                }
            );
            
            modelBuilder.Entity<PatientLabResult>().HasData(
                new PatientLabResult()
                {
                    Id = 1,
                    Patient_id = 1,
                    Lab_visit_id = 1,
                    Test_name = "a certain test name",
                    Test_result = "a certain test result",
                    Test_observation = "a certain test observation",
                    Attachments = "a certain attachment",
                    CreatedAt = new DateTime(2024, 2, 4)
                },
                new PatientLabResult()
                {
                    Id = 2,
                    Patient_id = 2,
                    Lab_visit_id = 2,
                    Test_name = "yet another certain test name",
                    Test_result = "yet another certain test result",
                    Test_observation = "yet another certain test observation",
                    Attachments = "yet antoher certain attachment",
                    CreatedAt = new DateTime(2024, 2, 4)
                }
            );

            base.OnModelCreating(modelBuilder);
            //modelBuilder.ApplyConfiguration() 
            //Conventions.Remove<PluralizingTableNameConvention>();
            Console.WriteLine("Done sending data to Patient table");
        }

        
    }
}


