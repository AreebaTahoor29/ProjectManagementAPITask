# ProjectManagementAPI

A simple RESTful API for managing projects and their tasks, built using **ASP.NET Core Web API**, **Entity Framework Core**, **AutoMapper**, and **JWT-based authentication**.

---

## 💪 Tech Stack

* ASP.NET Core 8
* Entity Framework Core
* SQL Server
* AutoMapper
* JWT Authentication
* Swagger (Swashbuckle)

---

## 📦 Features

* CRUD operations for Projects
* CRUD operations for Project Tasks
* JWT-based user authentication
* AutoMapper-based DTO mapping
* Swagger UI for testing APIs
* In-memory JWT key generation (base64-encoded)
* Clean architecture and separation of concerns

---

## 🔧 Setup Instructions

### 1. Clone the repository

```bash
git clone https://github.com/your-username/ProjectManagementAPI.git
cd ProjectManagementAPI
```

### 2. Update the connection string

Edit `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=ProjectManagementDb;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

### 3. Run migrations and update the database

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

> Install EF CLI if needed:
>
> ```bash
> dotnet tool install --global dotnet-ef
> ```

### 4. Run the application

```bash
dotnet run
```

Open: `https://localhost:<port>/swagger`

---

## 🔐 Authentication

### Login Endpoint

```http
POST /api/auth/login
```

Request:

```json
{
  "username": "admin",
  "password": "1234"
}
```

Response:

```json
{
  "token": "<JWT_TOKEN_HERE>"
}
```

Use the token in Swagger UI Authorize dialog or in the `Authorization` header:

```
Authorization: Bearer <JWT_TOKEN>
```

---

## 📁 Folder Structure

```
├── Controllers
│   └── ProjectsController.cs
│   └── AuthController.cs
├── Dtos
│   └── CreateProjectDto.cs
│   └── TaskDto.cs
│   └── LoginDto.cs
├── Models
│   └── Project.cs
│   └── ProjectTask.cs
│   └── User.cs
├── Repositories
│   └── IProjectRepository.cs
│   └── ProjectRepository.cs
├── Mappings
│   └── ProfileMapping.cs
├── Data
│   └── AppDbContext.cs
├── Program.cs
└── appsettings.json
```

---

## 📌 Notes

* Passwords are stored in plain text for demo purposes. Use hashing in production.
* JWT signing key is generated in memory at runtime.
* Modify JWT `Issuer` and `Audience` as needed in `appsettings.json`.

---

## ✅ Sample SQL Insert (User)

```sql
INSERT INTO Users (Username, Password) VALUES ('admin', '1234');
```

---

## 🔍 Swagger Testing

* Navigate to: `https://localhost:<port>/swagger`

---
