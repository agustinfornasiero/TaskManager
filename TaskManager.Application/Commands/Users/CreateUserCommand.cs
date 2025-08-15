
using TaskManager.Application.Common;
using TaskManager.Application.DTOs.Users;

namespace TaskManager.Application.Commands.Users
{
    public record CreateUserCommand(CreateUserDto User) : ICommand<UserDto>;
}
