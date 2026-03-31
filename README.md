# University System API

## Overview
The University System API is a .NET 9-based application designed to manage and streamline university operations. It provides features for handling students, courses, departments, and other university-related entities. The API is built with a focus on scalability, maintainability, and modern development practices.

## Features
- **Student Management**: CRUD operations for student records, including paginated queries.
- **Course Management**: Manage course details and assignments.
- **Department Management**: Handle department-related data.
- **Pagination and Filtering**: Efficient data retrieval with support for pagination and filtering.
- **Response Wrapping**: Standardized API responses using `ResponseHandler`.
- **Entity Mapping**: Simplified object mapping using AutoMapper.

## Technologies Used
- **.NET 9**: Modern, high-performance framework for building APIs.
- **Entity Framework Core**: For database interactions.
- **MediatR**: Implements the mediator pattern for clean architecture.
- **AutoMapper**: Simplifies object-to-object mapping.
- **Microsoft SQL Server**: Database backend.

## Project Structure
The project follows a clean architecture approach with the following layers:
- **Application**: Contains business logic, DTOs, and query/command handlers.
- **Domain**: Core entities and domain logic.
- **Infrastructure**: Database context and external service integrations.
- **API**: Entry point for the application, containing controllers and middleware.

## Getting Started
### Prerequisites
- .NET 9 SDK
- Microsoft SQL Server
- Visual Studio 2026 (or any compatible IDE)

### Setup
1. Clone the repository:
   ```bash
   git clone https://github.com/MohamedMagdy945/university-system-API.git
   ```
2. Navigate to the project directory:
   ```bash
   cd university-system-API
   ```
3. Restore dependencies:
   ```bash
   dotnet restore
   ```
4. Update the database connection string in `appsettings.json`.
5. Apply migrations:
   ```bash
   dotnet ef database update
   ```
6. Run the application:
   ```bash
   dotnet run
   ```

## Usage
The API exposes endpoints for managing students, courses, and departments. Use tools like Postman or Swagger UI to interact with the API.

## Contributing
Contributions are welcome! Please fork the repository and submit a pull request.

## License
This project is licensed under the MIT License. See the LICENSE file for details.

## Contact
For questions or support, please contact Mohamed Magdy at [your-email@example.com].