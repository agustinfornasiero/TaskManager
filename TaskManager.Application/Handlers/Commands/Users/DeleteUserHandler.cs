using MediatR;
using TaskManager.Application.Commands.Users;
using TaskManager.Core.Interfaces;

namespace TaskManager.Application.Handlers.Commands.Users
{
    internal class DeleteUserHandler : IRequestHandler<DeleteUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await _userRepository.GetByIdAsync(request.Id);

            if (entity == null) throw new KeyNotFoundException("User Not Found");

            await _userRepository.DeleteAsync(entity.Id);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
