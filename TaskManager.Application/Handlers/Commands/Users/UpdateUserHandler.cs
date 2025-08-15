using AutoMapper;
using MediatR;
using TaskManager.Application.Commands.Users;
using TaskManager.Application.DTOs.Users;
using TaskManager.Core.Interfaces;

namespace TaskManager.Application.Handlers.Commands.Users
{
    internal class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateUserHandler(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await _userRepository.GetByIdAsync(request.Id, cancellationToken);

            if (entity == null) throw new KeyNotFoundException("User Not Found");

            _mapper.Map(request.User, entity);

            await _userRepository.UpdateAsync(entity);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<UserDto>(entity);
        }
    }
}
