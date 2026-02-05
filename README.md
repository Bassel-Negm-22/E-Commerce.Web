# E-Commerce.Web
E-Commerce Web API (ASP.NET Core)

## Overview
This project is a **RESTful E-Commerce Web API** built using **ASP.NET Core (.NET 8)** and **Entity Framework Core**.  
The main focus is applying **clean backend architecture**, correct **design patterns**, and **best practices**, rather than delivering a fully finished product.

The application follows **Clean / Onion Architecture**, ensuring clear separation of concerns, maintainability, scalability, and testability.

---

## Architecture
The solution is structured into the following layers:

### 1. Domain Layer
- Contains core business entities and business rules
- Independent of frameworks and infrastructure
- No dependency on ASP.NET Core or Entity Framework

### 2. Application / Service Layer
- Contains business logic and use cases
- Defines service interfaces and DTOs
- Coordinates repositories via abstractions

### 3. Infrastructure / Persistence Layer
- Implements data access using Entity Framework Core
- Contains DbContext, entity configurations, migrations, and data seeding
- Implements **Generic Repository** and **Unit of Work** patterns

### 4. Presentation Layer (Web API)
- ASP.NET Core Web API
- Handles HTTP requests and responses
- Uses controllers, routing, and Swagger

---

## Design Patterns Used

### Generic Repository Pattern
- Provides reusable data access logic
- Avoids duplication of CRUD operations
- Keeps data access consistent across entities

### Unit of Work Pattern
- Coordinates multiple repositories
- Ensures all database changes are committed in a single transaction
- Prevents partial saves and data inconsistency

### Dependency Injection
- Used across all layers
- Promotes loose coupling and testability

### DTO Pattern
- Separates API contracts from domain entities
- Prevents exposing internal models directly

---

## SOLID Principles Applied
- **Single Responsibility Principle** – each class has one responsibility
- **Open/Closed Principle** – behavior extended without modifying existing code
- **Liskov Substitution Principle** – interfaces implemented consistently
- **Interface Segregation Principle** – small, focused interfaces
- **Dependency Inversion Principle** – high-level modules depend on abstractions

---

## Asynchronous Programming
- Uses **async / await** for all database operations
- Prevents blocking server threads
- Improves scalability and responsiveness

---

## Database & Data Access
- SQL Server
- Entity Framework Core
- Fluent API configurations
- EF Core Migrations
- Data Seeding for initial data

---

## API Documentation
- Integrated **Swagger / OpenAPI**
- Automatically discovers endpoints
- Allows testing endpoints via UI

---

## Technologies Used
- ASP.NET Core Web API (.NET 8)
- Entity Framework Core
- SQL Server
- AutoMapper
- Swagger / OpenAPI
- Dependency Injection
- Async / Await

---

## Project Status
🚧 **Work in Progress**

This project is intentionally incomplete and is used to demonstrate:
- Correct backend architecture
- Design patterns
- Clean code principles
- Real-world API structure
