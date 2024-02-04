

using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Linq;
using System.Transactions;


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
            
            modelBuilder.Entity<Patient>().ToTable("patient");
            modelBuilder.Entity<Patient>().HasKey(a => a.Id);
            
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

            base.OnModelCreating(modelBuilder);
            //modelBuilder.ApplyConfiguration() 
            //Conventions.Remove<PluralizingTableNameConvention>();
            Console.WriteLine("Done sending data to Patient table");
        }
    }
}


