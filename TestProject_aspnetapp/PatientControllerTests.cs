

using System.Configuration;
using aspnetapp.DataAccessLayer.DBContexts;
using aspnetapp.DataAccessLayer.Repositories;
using aspnetapp.Model.Dto;
using Microsoft.EntityFrameworkCore;

namespace TestProject_aspnetapp;
using System;
using aspnetapp.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

public class Tests
{
    private PatientRepository GetPatientRepository()
    {
        string connectionString =
            "Data Source=localhost,3306;DataBase=patientdb;User Id=test_user_1;password=Test_user_1_p";
        //if (Configuration.GetConnectionString("devMySqlConnStr") != null)
        //{
        //    connectionString = Configuration.GetConnectionString("devMySqlConnStr");
        //};
        var optionsBuilder = new DbContextOptionsBuilder<PatientDbContext>();
        optionsBuilder.UseMySQL(connectionString);
        var  options = optionsBuilder.Options;
        var patientDbContext = new PatientDbContext(options);
        return  new PatientRepository(patientDbContext); 
    }
    
    [Fact]
    public async Task TestCreatePatient()
    {
        for (int i = 0; i < 15; ++i)
        {
            Random random = new Random();
            var controller = new PatientController(GetPatientRepository());
            var requestDto = new PatientAddDto
            {
                Ssn = (100000000 + random.Next() % 899999999).ToString(),
                Dob = new DateTime(1970, 7, 1),
                Email = "Email_" + random.Next(10) + "__unit_test@test.com",
                FirstName = "FName_" + random.Next(10) + "__unit_test",
                MiddleName = "M",
                LastName = "LName_" + random.Next(10) + "__unit_test",
                Address = "Address #_" + random.Next(10) + "__unit_test",
                City = "City #_" + random.Next(10) + "__unit_test",
                State = "California",
                Zip = "95000",
                CreatedAt = new DateTime(2024, 2, 1) 
            };
            var actionResult = await controller.CreatePatient(requestDto);
            Assert.NotNull(actionResult);    
        }
    }
    

    [Fact]
    public async Task GetByIdTest()
    {
        var controller = new PatientController(GetPatientRepository());
        var actionResult = await controller.GetPatientByPatientId(1);
        Assert.NotNull(actionResult);
    }
    
    
    // [Fact]
    // public async Task UpdateTest()
    // {
    // }
    

    // [Fact]
    // public async Task DeleteTest()
    // {
    // }
    
    
}