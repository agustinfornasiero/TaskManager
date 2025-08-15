
using TaskManager.Application.Common;
using TaskManager.Application.DTOs.Tasks;

namespace TaskManager.Application.Commands.Tasks
{
    public record ChangeTaskStatusCommand(Guid Id, Core.Enums.TaskStatus Status) : ICommand<TaskDto>;
    
}
