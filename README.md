# TaskManager
 Proyecto de Gestión de Tareas Colaborativas Challenge Técnico PWC, desarrollada con:
 - .NET 8
 - Minimal API
 - Clean Architecture
 - Entity Framework Core
 - Visual Studio 2022
 
 # Características
 - CRUD completo de Usuarios y Tareas.
 - Cambio de estado de tareas.
 - Arquitectura limpia.
 - Uso de CQRS con MediatR.
 - Persistencia con EF Core, Code First.
 - Documentación con Swagger

 # Requisitos Previos
 - .NET 8 SDK (https://learn.microsoft.com/en-us/download)
 - SQLite (https://sqlite.org/download)
 - Git (opcional para clonar el repositorio) 

 # Ejecución en local
 1. Clonar el repositorio 
    git clone https://github.com/agustinfornasiero/TaskManager
    cd TaskManager

 2. Restaurar Paquetes
    dotnet restore

 3. Aplicar migraciones
    cd TaskManager.Infrastructure
    dotnet ef database update (En caso de error, asegurarse tener el CLI instalado: dotnet tool install --global dotnet-ef)

 4. Ejecutar API
    cd ../TaskManager.API
    dotnet run 

 5. Acceder a Swagger
    https://localhost:5001/swagger
    http://localhost:5000/swagger
    

 # Endpoints Principales
 - Usuarios
    => GET
        => /api/users               Lista todos los usuarios
        => /api/users/{id}          Obtiene un usuario por ID
    => POST
        => /api/users               Crea un nuevo usuario
    => PUT
        => /api/users/{id}          Actualiza un usuario
    => DELETE
        => /api/users/{id}          Elimina un usuario

- Tasks
    => GET
        => /api/tasks               Lista todas las tareas
        => /api/tasks/{id}          Obtiene una task por ID

    => POST
        => /api/tasks               Crea una nueva tarea
    => PUT
        => /api/tasks/{id}/status   Cambia el estado de una tarea
    => DELETE
        => /api/tasks/{id}          Elimina una task

# Decisiones de Diseño
- Se utilizó CQRS con MediatR para separar comandos de consultas.
- Se implementó Clean Architecture para garantizar bajo acoplamiento.
- Se creó un repositorio genérico para reducir duplicación de código.
- Se utilizó Automapper para la conversión DTO <=> Entidades.
- Base de datos implementada con EF Core Code First.
- Patrones de diseños:
    - Aggregate Root: TaskItem actúa como agregado que controla sus TaskEvents.
    - Encapsulamiento y validaciones en el dominio (Single Responsibility y Liskov donde corresponde).
    - Repository pattern definido por interfaces en Core (Implementación en Infrastructure).
    - IUnitOfWork para coordinar persistencia (se implementa con DbContext).

# Mejoras posibles
- Implementar paginación y filtros en las consultas.
- Agreagar validaciones con FluentValidations.
- Implementar autenticación con JWT.
- Test unitarios y de integración.
- Manejo de errores con Middleware.


