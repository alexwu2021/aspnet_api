### Overall Instruction for Environment Setup and Run 

# prerequisite for running this app: you need your access to a mysql instance, local or remote 


# Step 1: 
locate this file: aspnet_api/aspnetapi/appsettings.Development.json

and change the user name and password for your db environment

```
"devMySqlConnStr": "Data Source=localhost,3306;DataBase=patientdb;User Id=test_user_1;password=Test_user_1_p"
```

# Step 2: cd the aspnetapi folder, and type the following command
```
dotnet buil
dotnet run
```

after this, a default browser will pop up, and we can try the follow the API end points 
```
[HTTPGET] https://localhost:5000/api/test
[HTTPGET] https://localhost:5001/api/v1/patient      --> show all the patients
[HTTPGET] https://localhost:5001/api/v1/patient/1    --> show a particular patient, here is 1
[HTTPPOST] https://localhost:5001/api/v1/patient     --> for creating a new patient
```
you may want to use postman to do the post, as of now, the patient create functionality is up, as proven
by the unit tests. 















## Development notes

1. nuget install this dependency first: Microsoft.EntityFrameworkCore.Design

2. then run this script to install dotnet-ef
```
dotnet tool install --global dotnet-ef --version 8.0
```

3. for schema changes, need run the following script
```
dotnet ef migrations add ${migration name}
```