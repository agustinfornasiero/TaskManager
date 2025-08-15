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
            var users = _userRepository.GetAllAsync(cancellationToken);

            return _mapper.Map<IEnumerable<UserDto>>(users);
        }
    }
}
