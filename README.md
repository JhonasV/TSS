# TSS

TSS is app to import and export TSS employees

Client made with ReactJs

## Features
- Export and Import Employees in XML:
- List of employees

## Technologies
- ASP.NET Core 5 API 
- EntityFramework Core

## Installation

Restore the dependecies in the folder `TSS` root

```bash
dotnet restore
```
Copy file `appsettings.json` with the name `appsettings.Development.json` and add Sql Server connection string 

```bash
  "ConnectionStrings": {
     "DefaultConnection": "Server={server};Database={database};User Id={user};Password={password};"
  }
```
Setup the database
(if database exists ignore this step)

```bash
Update-database
```
OR  
### EF CORE CLI

```bash
dotnet ef database update 
```


## Run the project
Go to the project root folder
```bash
dotnet run -p TSS
```

App must be running in ports:
```bash
 localhost:5001 OR localhost:5000
```



