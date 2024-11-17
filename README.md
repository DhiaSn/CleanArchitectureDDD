# CleanArchitectureDDD

## Overview
CleanArchitectureDDD is a modular project implementing the Clean Architecture design pattern. The solution emphasizes separation of concerns and scalability, ensuring maintainability and testability.

## Project Structure
The project is organized into four primary layers, each serving a distinct purpose:

### 1. **Core Layer (`CleanArchitectureDDD.Core`)**
   - Defines the core domain logic and business rules.
   - Independent of any external dependencies.
   - **Key Components**:
     - **Entities**: Domain models (e.g., `Car.cs`, `Client.cs`).
     - **Interfaces**: Contracts for repositories and services (e.g., `IGenericRepository.cs`).
     - **Specifications**: Encapsulates query logic for reuse (e.g., `BaseSpecification.cs`).

### 2. **Application Layer (`CleanArchitectureDDD.App`)**
   - Implements use cases and application-specific logic.
   - Bridges the Core layer with Infrastructure and GRPC layers.
   - **Key Components**:
     - **DTOs**: Data Transfer Objects for communication (e.g., `ClientDto.cs`).
     - **Services**: Business logic implementations (e.g., `ClientService.cs`).
     - **Wrappers**: Standardized response objects (e.g., `Response.cs`).

### 3. **Infrastructure Layer (`CleanArchitectureDDD.Infrastructure`)**
   - Handles database interactions, external services, and configurations.
   - **Key Components**:
     - **Data**: Entity Framework database context and seeding logic.
     - **Repositories**: Concrete repository implementations.
     - **Migrations**: Database migration scripts for schema management.

### 4. **GRPC Layer (`CleanArchitectureDDD.GRPC`)**
   - Exposes APIs via gRPC for efficient inter-service communication.
   - **Key Components**:
     - **Protos**: `.proto` files defining gRPC services.
     - **Services**: Implementation of gRPC service logic.

### Folder Structure
Below is the detailed project structure:

CleanArchitectureDDD/
├── CleanArchitectureDDD.Core/
│   ├── Entities/
│   │   ├── Car.cs
│   │   ├── Client.cs
│   │   └── ...
│   ├── Interfaces/
│   │   ├── IGenericRepository.cs
│   │   └── ...
│   ├── Specifications/
│   │   ├── BaseSpecification.cs
│   │   ├── ClientSpecification.cs
│   │   └── ...
│   └── ...
├── CleanArchitectureDDD.App/
│   ├── DTOs/
│   │   ├── ClientDto.cs
│   │   └── ...
│   ├── Services/
│   │   ├── ClientService.cs
│   │   └── ...
│   ├── Wrappers/
│   │   ├── Response.cs
│   │   └── ...
│   └── ...
├── CleanArchitectureDDD.Infrastructure/
│   ├── Data/
│   │   ├── ApplicationDbContext.cs
│   │   ├── DbInitializer.cs
│   │   └── ...
│   ├── Repositories/
│   │   ├── GenericRepository.cs
│   │   └── ...
│   ├── Migrations/
│   │   └── ...
│   └── ...
├── CleanArchitectureDDD.GRPC/
│   ├── Protos/
│   │   ├── client.proto
│   │   └── ...
│   ├── Services/
│   │   ├── ClientService.cs
│   │   └── ...
│   └── ...
└── ...


## Key Features
- **Clean Architecture**: Ensures modularity and separation of concerns.
- **gRPC Integration**: Offers high-performance RPC communication.
- **Entity Framework**: Simplifies data access and migrations.
- **Validation and Error Handling**: Provides robust exception handling and middleware.



