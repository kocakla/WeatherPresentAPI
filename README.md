# Weather API

A RESTful Weather API built with .NET 9, featuring JWT-based authentication and Entity Framework Core for data access.

---

## Features

- User Registration and Login with JWT Authentication  
- Management of Locations and Weather data models  
- Usage of enums for wind direction and wind speed  
- Swagger UI integration for easy testing and API documentation  
- Repository Pattern and AutoMapper integration  
- FluentValidation for request validation  
- Secure endpoints protected by JWT tokens

---

## Technologies

- .NET 9  
- Entity Framework Core (using SQLite by default, configurable)  
- JWT Authentication  
- AutoMapper  
- FluentValidation  
- Swagger (Swashbuckle)

---

## Project Structure

/Controllers  
/Data  
/Models  
/Services  
/Repositories  
/Dtos  

---

## API Endpoints Summary

| Endpoint              | Method | Description                        |
|-----------------------|--------|----------------------------------|
| `/api/auth/register`  | POST   | Register a new user               |
| `/api/auth/login`     | POST   | User login and receive JWT token |
| `/api/locations`      | GET    | Retrieve all locations            |
| `/api/weather`        | POST   | Add new weather data              |

---

## Getting Started

1. Clone the repository  
```bash
git clone https://github.com/yourusername/weather-api.git
cd weather-api
dotnet restore
dotnet ef database update
dotnet run

---

## Configuration

The application uses `appsettings.json` for configuration. Important settings include:

- **ConnectionStrings:DefaultConnection** — database connection string.
- **JwtSettings:**  
  - `SecretKey`: Secret key for JWT token signing (keep it safe and private).  
  - `Issuer`: Token issuer identifier.  
  - `Audience`: Intended audience of the token.  
  - `ExpirationMinutes`: Token validity duration in minutes.

You can override these settings via environment variables in production.

