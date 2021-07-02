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
Add Sql Server connection string in  `TSS/appsettings.development.json` file

```bash
 "DefaultConnection": "Server={server};Database={database};User Id={user};Password={password};"
```
Go in the root of the folder `TSS` and setup the database


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

App Running must be running in ports:
```bash
 localhost:5001 OR localhost:5000
```



