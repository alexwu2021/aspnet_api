

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
    
    [SetUp]
    public void Setup()
    {
    }

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
            Id = -1,
            Ssn = "123456789",
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

    
    /*
    [Fact]
    public async Task GetListTest()
    {
        var facadeResult = new PaginationDto<CustomerResponseDto>
        {
            Count = 2,
            Result = new List<CustomerResponseDto>
            {
                new()
                {
                    Email = "tarnished@test.com",
                    FirstName = "Elden",
                    Surname = "Ring",
                    FullName = "Elden Ring",
                    Id = 1
                },
                new()
                {
                    Email = "nameless_king@test.com",
                    FirstName = "Elden",
                    Surname = "King",
                    FullName = "Elden King",
                    Id = 2
                }
            }
        };

        var cancellationTokenSource = new CancellationTokenSource();

        _customerFacade.Setup(x => x.GetListByFilterAsync(It.IsAny<CustomerFilterDto>(), cancellationTokenSource.Token)).ReturnsAsync(facadeResult);

        var controller = new CustomerController(_correlationContext.Object, _logger.Object, _customerFacade.Object);

        var requestDto = new CustomerFilterDto
        {
            FirstName = "Elden"
        };

        var actionResult = await controller.Get(requestDto, cancellationTokenSource.Token);

        Assert.NotNull(actionResult);
        Assert.Equal(2, actionResult?.Value?.Count);
        Assert.Equal(2, actionResult?.Value?.Result.Count(x => x.FirstName == "Elden"));
    }

    [Fact]
    public async Task GetByIdTest()
    {
        var facadeResult = new CustomerResponseDto
        {
            Email = "tarnished@test.com",
            FirstName = "Elden",
            Surname = "Ring",
            FullName = "Elden Ring",
            Id = 1
        };

        var cancellationTokenSource = new CancellationTokenSource();

        _customerFacade.Setup(x => x.GetByFilterAsync(It.IsAny<CustomerFilterDto>(), cancellationTokenSource.Token)).ReturnsAsync(facadeResult);

        var controller = new CustomerController(_correlationContext.Object, _logger.Object, _customerFacade.Object);

        var actionResult = await controller.Get(1, cancellationTokenSource.Token);

        Assert.NotNull(actionResult);
        Assert.Equal(1, actionResult?.Value?.Id);
        Assert.Equal("tarnished@test.com", actionResult?.Value?.Email);
    }

    
    [Fact]
    public async Task PutTest()
    {
        var cancellationTokenSource = new CancellationTokenSource();

        _customerFacade.Setup(x => x.UpdateAsync(It.IsAny<long>(), It.IsAny<CustomerRequestDto>(), cancellationTokenSource.Token));

        var controller = new CustomerController(_correlationContext.Object, _logger.Object, _customerFacade.Object);

        var requestDto = new CustomerRequestDto
        {
            ConfirmPassword = "123DarkSouls!",
            Password = "123DarkSouls!",
            Email = "chosen_one@test.com",
            FirstName = "Dark",
            Surname = "Souls"
        };

        var actionResult = await controller.Put(1, requestDto, cancellationTokenSource.Token);

        Assert.NotNull(actionResult);
    }

    [Fact]
    public async Task DeleteTest()
    {
        var cancellationTokenSource = new CancellationTokenSource();

        _customerFacade.Setup(x => x.DeleteAsync(It.IsAny<long>(), cancellationTokenSource.Token));

        var controller = new CustomerController(_correlationContext.Object, _logger.Object, _customerFacade.Object);

        var actionResult = await controller.Delete(1, cancellationTokenSource.Token);

        Assert.NotNull(actionResult);
    }
    
    */
}