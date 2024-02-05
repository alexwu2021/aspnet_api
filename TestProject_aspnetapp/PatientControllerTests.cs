

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
        var controller = new PatientController(GetPatientRepository());
        var requestDto = new PatientAddDto
        {
            Ssn = "987654321",
            Dob = new DateTime(1970, 7, 1),
            Email = "1101@test.com",
            FirstName = "Jone",
            MiddleName = "M",
            LastName = "Doe",
            Address = "Some where",
            City = "City of NoWhere",
            State = "California",
            Zip = "95000",
            CreatedAt = new DateTime(2024, 2, 1) 
        };
        var actionResult = await controller.CreatePatient(requestDto);
        Assert.NotNull(actionResult);
    }
    

    [Fact]
    public async Task GetByIdTest()
    {
        var controller = new PatientController(GetPatientRepository());
        var actionResult = await controller.GetPatientByPatientId(1);
        Assert.NotNull(actionResult);
    }
    
    
    [Fact]
    public async Task UpdateTest()
    {
    }
    

    [Fact]
    public async Task DeleteTest()
    {
    }
    
    
}