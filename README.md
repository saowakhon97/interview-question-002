# Interview Question 002

A simple authentication system built with ASP.NET Core 10 and Angular 21.

## Features

- User Registration
- User Login
- JWT Authentication
- Password Hashing (BCrypt)
- User Profile
- Dashboard
- Logout
- Route Guard
- HTTP JWT Interceptor
- Swagger JWT Authentication

---

## Technology Stack

### Backend

- ASP.NET Core 10 Web API
- Entity Framework Core
- SQLite
- JWT Authentication
- BCrypt.Net

### Frontend

- Angular 21
- TypeScript
- Bootstrap 5
- Reactive Forms

---

## Project Structure

```
Backend
│
├── Example.Api
├── Example.Application
├── Example.Domain
└── Example.Infrastructure

Frontend
│
└── example-web
```

---

## Prerequisites

- .NET 10 SDK
- Node.js 20+
- Angular CLI
- SQLite

---

## Backend Setup

Clone repository

```bash
git clone <repository-url>
```

Go to backend

```bash
cd Backend/Example.Api
```

Restore packages

```bash
dotnet restore
```

Run Migration

```bash
dotnet ef database update
```

Run API

```bash
dotnet run
```

Swagger

```
https://localhost:7246/swagger
```

---

## Frontend Setup

Go to frontend

```bash
cd Frontend
```

Install packages

```bash
npm install
```

Run Angular

```bash
ng serve
```

Open

```
http://localhost:4200
```

---

## Authentication Flow

1. Register new account
2. Password is hashed using BCrypt
3. Login
4. API returns JWT Token
5. Angular stores token in Local Storage
6. JWT Interceptor attaches Bearer Token
7. Dashboard requests user profile
8. Logout removes token

---

## API Endpoints

| Method | Endpoint | Description |
|---------|----------|-------------|
| POST | /api/auth/register | Register new user |
| POST | /api/auth/login | Login |
| GET | /api/auth/profile | Get current user profile |

---

## Database

SQLite

Main table

### Users

| Column | Type |
|---------|------|
| Id | Guid |
| Username | string |
| PasswordHash | string |

Passwords are stored using BCrypt hashing.

---

## Screenshots

- Login
- Register
- Dashboard
- Swagger

---

## Notes

- JWT Authentication
- BCrypt Password Hashing
- Route Guard
- HTTP Interceptor
- Protected API Endpoint
