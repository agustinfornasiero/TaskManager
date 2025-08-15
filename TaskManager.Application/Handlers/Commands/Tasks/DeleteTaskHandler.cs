
using MediatR;
using TaskManager.Application.Commands.Tasks;
using TaskManager.Core.Interfaces;

namespace TaskManager.Application.Handlers.Commands.Tasks
{
    internal class DeleteTaskHandler : IRequestHandler<DeleteTaskCommand, Unit>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTaskHandler(ITaskRepository tasRepositor, IUnitOfWork unitOfWork)
        {
            _taskRepository = tasRepositor;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var entity = await _taskRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity == null) throw new KeyNotFoundException("Task Not Found");

            await _taskRepository.DeleteAsync(entity.Id, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
