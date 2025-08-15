using AutoMapper;
using MediatR;
using TaskManager.Application.DTOs.Users;
using TaskManager.Application.Queries.Users;
using TaskManager.Core.Interfaces;

namespace TaskManager.Application.Handlers.Queries.Users
{
    internal class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserDto?>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserByIdHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);

            return user == null ? null : _mapper.Map<UserDto>(user);
        }
    }
}
