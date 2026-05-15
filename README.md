# Employee Management System API

A RESTful API built with ASP.NET Core, Entity Framework Core, and SQL Server for managing employee records.

## Features
- Create employees
- Retrieve all employees
- Retrieve employee by ID
- Update employee information
- Delete employees

## Tech Stack
- C#
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Visual Studio

## Endpoints

### Get All Employees
```http
GET /api/ems

### Get Employee By Id
GET /api/ems/{id}

### Create Employee
POST /api/ems

### Update Employee
PUT /api/ems/{id}

###Delete Employee
DELETE /api/ems/{id}
