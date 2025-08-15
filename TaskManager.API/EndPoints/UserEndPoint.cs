using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Commands.Users;
using TaskManager.Application.DTOs.Users;
using TaskManager.Application.Queries.Tasks;
using TaskManager.Application.Queries.Users;

namespace TaskManager.API.EndPoints
{
    public static class UserEndPoint
    {
        public static void MapUserEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/users");

            // Obtener todos los usuarios
            group.MapGet("/", async (IMediator mediator) =>
            {
                return Results.Ok(await mediator.Send(new GetAllUsersQuery()));
            });

            // Obtener usuario por ID
            group.MapGet("/{id:guid}", async (Guid id, IMediator mediator) =>
            {
                var result = await mediator.Send(new GetUserByIdQuery(id));
                return result is not null ? Results.Ok(result) : Results.NotFound();
            });

            // Crear usuario
            group.MapPost("/", async ([FromBody] CreateUserDto dto, IMediator mediator) =>
            {
                var result = await mediator.Send(new CreateUserCommand(dto));
                return Results.Created($"/api/users/{result.Id}", result);
            });

            // Actualizar usuario
            group.MapPut("/{id:guid}", async ([FromRoute] Guid id, [FromBody] UpdateUserDto dto, IMediator mediator) =>
            {
                var result = await mediator.Send(new UpdateUserCommand(id, dto));
                return Results.Ok(result);
            });

            // Eliminar usuario
            group.MapDelete("/{id:guid}", async ([FromRoute] Guid id, IMediator mediator) =>
            {
                await mediator.Send(new DeleteUserCommand(id));
                return Results.NoContent();
            });
        }
    }
}
