# OnlineStore - SnappFood Project 


![image](https://github.com/danial-riazati/OnlineStore/assets/58943927/a6df5414-cdae-4cdf-bbc2-5ee93f064766)
<br/>
<br/>


OnlineStore is developed using .NET 6 and adhering to Clean Architecture principles. The application is structured to ensure scalability, maintainability, and a clear separation of concerns through a series of interconnected projects.

## Project Structure

The solution is divided into several projects, each with a specific role:

- **OnlineStore.Domain**: Contains the enterprise business logic and entities.
- **OnlineStore.Application**: Handles all application logic, orchestrated via CQRS and Mediator patterns.
- **OnlineStore.API**: The entry point for the frontend, exposing RESTful APIs.
- **OnlineStore.Infrastructure**: Implements persistence and other concerns like caching and logging.
- **OnlineStore.Application.Test**: Contains unit tests for the application layer using xUnit and Moq.

## Technologies and Patterns

The solution leverages a range of technologies and design patterns:

- **.NET 6**: The framework for building high-performance, cross-platform applications.
- **Entity Framework Core**: ORM used for data access, configured for a code-first approach.
- **MS SQL Server**: Primary relational database.
- **MemCache**: Utilized for caching using Microsoft.Extensions.Caching.Memory.
- **Serilog**: For sophisticated logging capabilities.
- **MediatR**: Implements the Mediator pattern to reduce dependencies.
- **Unit of Work**: Ensures that multiple operations are executed in a single transaction.
- **AutoMapper**: For object-object mapping.
- **FluentValidation**: For validation rules.
- **ASP.NET Core API Versioning**: Adds service versioning directly to the API routes and headers.
- **ASP.NET Core Rate Limiting (AspNetCoreRateLimit)**: IP-based rate limiting using MemCache.
- **Moq**: For mocking objects in tests.
- **Swagger**: Configured for API documentation and testing interface.
- **Docker**: Containerization of the application and database.

## Development Tools

- **Makefile**: Simplifies tasks like database migrations and updates.
- **Docker Compose**: Orchestrates multi-container Docker applications, defining two main services: the application itself and the MS SQL database.

## Getting Started

### Prerequisites

- Docker
- .NET 6 SDK
- Any suitable IDE (like Visual Studio or VS Code)

### Running the Application

1. Clone the repository:
``` git clone "https://github.com/danial-riazati/OnlineStore" ```
2. Navigate to the project directory:
``` cd OnlineStore ```
3. Use Docker Compose to build and start the services:
``` docker-compose up --build ```

This will set up the entire application, including the database and the API service. The application should now be accessible at http://localhost:5050.

### API Documentation
Once the application is running, API documentation can be accessed via Swagger at http://localhost:5000/swagger.




