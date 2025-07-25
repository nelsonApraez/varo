# Varo - Project Management and Metrics System

Varo is a comprehensive project management system designed to track solutions, consultancies, and technical metrics. It provides functionality for monitoring code quality, agile metrics, team performance, and project oversight.

## Features

- **Solution Management**: Track and manage software solutions with comprehensive metrics
- **Consultancy Management**: Oversee consultancy projects and their progress
- **Quality Metrics**: Monitor code quality and technical debt
- **Agile Metrics**: Track sprint metrics and team performance
- **Audit Management**: Manage audits for both solutions and consultancies
- **Technology Tracking**: Monitor technology usage across projects
- **Team Management**: Track team composition and performance
- **Reporting**: Generate comprehensive reports with Power BI integration

## Architecture

The project follows a layered architecture pattern:

- **Varo.Web**: ASP.NET MVC web application (presentation layer)
- **Varo.Api**: RESTful API for external integrations
- **Varo.Soluciones**: Business logic for solution management
- **Varo.Consultorias**: Business logic for consultancy management
- **Varo.Maestros**: Master data management (users, clients, technologies)
- **Varo.Transversales**: Cross-cutting concerns and utilities
- **Varo.SqlAzure**: Database schema and stored procedures

## Prerequisites

- .NET Framework 4.7.2 or higher
- SQL Server 2016 or Azure SQL Database
- Visual Studio 2019 or higher (for development)
- IIS 8.0 or higher (for deployment)

## Configuration

Before running the application, update the following configuration files:

### Database Connection
Update `Web.config` in the Varo.Web project:
```xml
<connectionStrings>
    <add name="VaroConnectionString" 
         connectionString="Server=your-server;Database=varo-db;User ID=your-user;Password=your-password;..." 
         providerName="System.Data.SqlClient" />
</connectionStrings>
```

### Application Settings
Configure these keys in `Web.config`:
- `ClientId`: Your Azure AD application ID
- `ClientSecret`: Your Azure AD application secret
- `TenantId`: Your Azure AD tenant ID
- `EmailSender`: System email address
- `PasswordApp365`: Email system password

## Building the Project

1. Clone the repository
2. Open `Varo.sln` in Visual Studio
3. Restore NuGet packages
4. Build the solution

## Running Tests

The project includes unit tests for core functionality:
- `Varo.Maestros.Test`
- `Varo.Consultorias.Test`
- `Varo.Soluciones.Test`

Run tests using Visual Studio Test Explorer or:
```
dotnet test
```

## Deployment

1. Build the solution in Release mode
2. Deploy the database schema using the `Varo.SqlAzure` project
3. Deploy the web application to IIS
4. Configure connection strings and application settings

## Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Add tests for new functionality
5. Submit a pull request

## License

This project is licensed under the MIT License - see the LICENSE file for details.