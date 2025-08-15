using MediatR;
using TaskManager.Application.DTOs.Tasks;

namespace TaskManager.Application.Queries.Tasks
{
    public record GetAllTasksQuery() : IRequest<IEnumerable<TaskDto>>;
}
