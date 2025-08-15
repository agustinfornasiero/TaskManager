
using TaskManager.Application.Common;

namespace TaskManager.Application.Commands.Tasks
{
    public record DeleteTaskCommand(Guid Id) : ICommand;
    
}
