# 🏫 School REST API

A RESTful API built with **ASP.NET Core** demonstrating professional backend architecture patterns including Repository Pattern, Service Layer, JWT Authentication, and AutoMapper.

---

## ✨ Features

- **JWT Authentication** — register, login, Bearer token auth
- **Full CRUD** — complete Create, Read, Update, Delete for students
- **Repository Pattern** — clean separation between data access and business logic
- **Service Layer** — business logic isolated from controllers
- **DTOs** — separate input and response models
- **AutoMapper** — automatic model-to-DTO mapping
- **Input Validation** — Data Annotations on all request models
- **Error Handling** — global middleware returning structured JSON errors
- **Swagger UI** — interactive API documentation with Bearer token support

---

## 🏗️ Architecture

```
Controller → Service → Repository → Database
```

- **Controllers** — receive HTTP requests, call service, return response
- **Services** — business logic, DTO mapping with AutoMapper
- **Repositories** — all database access via Entity Framework Core
- **Middleware** — global error handling

---

## 🛠️ Tech Stack

| Layer | Technology |
|---|---|
| Framework | ASP.NET Core |
| ORM | Entity Framework Core |
| Database | SQL Server |
| Authentication | JWT Bearer Tokens |
| Mapping | AutoMapper |
| Documentation | Swagger / Swashbuckle |
| Language | C# |

---

## 🔑 API Endpoints

### Auth
| Method | Endpoint | Description | Auth |
|---|---|---|---|
| POST | /api/auth/register | Create account | Public |
| POST | /api/auth/login | Login + get token | Public |

### Students
| Method | Endpoint | Description | Auth |
|---|---|---|---|
| GET | /api/students | Get all students | Required |
| GET | /api/students/{id} | Get student by id | Required |
| POST | /api/students | Create student | Required |
| PUT | /api/students/{id} | Update student | Required |
| DELETE | /api/students/{id} | Delete student | Required |

---

## ⚙️ Setup & Run Locally

### Prerequisites
- .NET 9 SDK
- SQL Server
- Visual Studio 2022

### Steps

1. Clone the repo
```bash
git clone https://github.com/Othdu/SchoolAPI.git
cd SchoolAPI
```

2. Update connection string in `appsettings.json`
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=SchoolAPIDB;Integrated Security=True;TrustServerCertificate=True;Encrypt=False;"
}
```

3. Update JWT settings
```json
"JwtSettings": {
  "SecretKey": "YourSuperSecretKeyHere",
  "Issuer": "SchoolAPI",
  "Audience": "SchoolAPIUsers",
  "ExpiryHours": 1
}
```

4. Run migrations
```bash
dotnet ef database update
```

5. Run the project
```bash
dotnet run
```

6. Open Swagger at `http://localhost:5000/swagger`

---

## 🔐 Authentication Flow

1. Register → `POST /api/auth/register`
2. Login → `POST /api/auth/login` → copy the token
3. Click **Authorize** in Swagger → enter `Bearer {token}`
4. All student endpoints are now accessible
=
