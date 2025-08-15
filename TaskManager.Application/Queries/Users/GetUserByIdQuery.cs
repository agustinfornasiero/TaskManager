
using TaskManager.Application.Common;
using TaskManager.Application.DTOs.Users;

namespace TaskManager.Application.Queries.Users
{
    public record GetUserByIdQuery(Guid Id) : IQuery<UserDto?>;
    
}
