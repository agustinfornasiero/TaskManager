using AutoMapper;
using MediatR;
using TaskManager.Application.DTOs.Users;
using TaskManager.Application.Queries.Users;
using TaskManager.Core.Interfaces;

namespace TaskManager.Application.Handlers.Queries.Users
{
    internal class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetAllUsersHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            // Espera la tarea para obtener la lista de usuarios
            var users = await _userRepository.GetAllAsync(cancellationToken);

            // Mapea la lista de usuarios a UserDto
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }
    }
}
