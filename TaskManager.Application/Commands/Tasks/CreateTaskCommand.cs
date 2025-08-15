
using TaskManager.Application.Common;
using TaskManager.Application.DTOs.Tasks;

namespace TaskManager.Application.Commands.Tasks
{
    public record CreateTaskCommand(CreateTaskDto Task) : ICommand<TaskDto>;
    
}
