using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Commands.Tasks;
using TaskManager.Application.DTOs.Tasks;
using TaskManager.Application.Queries.Tasks;

namespace TaskManager.API.EndPoints
{
    public static class TaskEndpoint
    {
        public static void MapTaskEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/tasks");

            // Obtener todas las tareas
            group.MapGet("/", async (IMediator mediator) =>
            {
                return Results.Ok(await mediator.Send(new GetAllTasksQuery()));
            });

            // Obtener tarea por ID
            group.MapGet("/{id:guid}", async (Guid id, IMediator mediator) =>
            {
                var result = await mediator.Send(new GetTaskByIdQuery(id));
                return result is not null ? Results.Ok(result) : Results.NotFound();
            });

            // Crear tarea
            group.MapPost("/", async ([FromBody] CreateTaskDto dto, IMediator mediator) =>
            {
                var result = await mediator.Send(new CreateTaskCommand(dto));
                return Results.Created($"/api/tasks/{result.Id}", result);
            });

            // Cambiar el estado de la tarea
            group.MapPut("/{id:guid}/status", async ([FromRoute] Guid id, [FromBody] TaskDto dto, IMediator mediator) =>
            {
                var result = await mediator.Send(new ChangeTaskStatusCommand(id, dto.Status));
                return Results.Ok(result);
            });

            // Eliminar tarea
            group.MapDelete("/{id:guid}", async ([FromRoute] Guid id, IMediator mediator) =>
            {
                await mediator.Send(new DeleteTaskCommand(id));
                return Results.NoContent();
            });
        }
    }
}