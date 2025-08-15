
using TaskManager.Application.Common;

namespace TaskManager.Application.Commands.Users
{
    public record DeleteUserCommand(Guid Id) : ICommand;
    
}
