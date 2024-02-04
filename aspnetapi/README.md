### Overall Instruction for Environment Setup and Run 

# Step 1: launch dockerd
this can be achieved by just launching docker desktop
once the docker desktop UI is visible, we are good


# Step 2: cd the aspnetapi folder, and type the following command

```
docker run -d --name azuresqledge --cap-add SYS_PTRACE \
  -e 'ACCEPT_EULA=1' \
  -e 'MSSQL_SA_PASSWORD=Str#ng_Passw#rd' \
  -p 57000:1433 \
   mcr.microsoft.com/azure-sql-edge
```
this will bring up an azure sql instance, listening to port 1433 in docker mapped to 57000 in the host


# Step 3: launch the app
```
dotnet buil
dotnet run
```

after this, we can access the API end points like 
```
http://localhost:5000/api/test

```



## Development notes

1. nuget install this dependency first: Microsoft.EntityFrameworkCore.Design

2. then run this script
```
dotnet tool install --global dotnet-ef --version 8.0
```

3. for schema changes, need run the following script
```
dotnet ef migrations add ${migration name}
```