# ASP.NET Core 6 Web API con Entity Framework Core y MediatR y más.

Este proyecto es una API RESTful desarrollada con ASP.NET Core 6, utilizando Entity Framework Core para la gestión de datos y MediatR para implementar el patrón CQRS (Command Query Responsibility Segregation). La API gestiona entidades `Factura` con operaciones CRUD.

## Requisitos

- .NET 6 SDK
- SQL Server
- Ef Core

## Configuración del Proyecto

### Configuración de la Base de Datos

1. Asegúrate de tener SQL Server instalado y ejecutándose en tu máquina.
2. Actualiza la cadena de conexión en el archivo `appsettings.json` según tu configuración de SQL Server:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=YourDatabaseName;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
