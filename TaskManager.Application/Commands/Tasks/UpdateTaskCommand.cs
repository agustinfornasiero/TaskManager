
using TaskManager.Application.Common;
using TaskManager.Application.DTOs.Tasks;

namespace TaskManager.Application.Commands.Tasks
{
    public record UpdateTaskCommand(Guid Id, UpdateTaskDto Task) : ICommand<TaskDto>;
    
}
