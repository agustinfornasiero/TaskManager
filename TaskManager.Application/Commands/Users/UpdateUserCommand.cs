
using TaskManager.Application.Common;
using TaskManager.Application.DTOs.Users;

namespace TaskManager.Application.Commands.Users
{
    public record UpdateUserCommand(Guid Id, UpdateUserDto User) : ICommand<UserDto>;
}
