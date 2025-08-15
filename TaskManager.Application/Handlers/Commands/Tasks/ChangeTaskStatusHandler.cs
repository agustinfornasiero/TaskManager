
using AutoMapper;
using MediatR;
using TaskManager.Application.Commands.Tasks;
using TaskManager.Application.DTOs.Tasks;
using TaskManager.Core.Interfaces;

namespace TaskManager.Application.Handlers.Commands.Tasks
{
    internal class ChangeTaskStatusHandler : IRequestHandler<ChangeTaskStatusCommand, TaskDto>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ChangeTaskStatusHandler(ITaskRepository taskRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<TaskDto> Handle(ChangeTaskStatusCommand request, CancellationToken cancellationToken)
        {
            var entity = await _taskRepository.GetByIdAsync(request.Id);
            if (entity == null) throw new KeyNotFoundException("Task Not Found");

            entity.ChangeStatus(request.Status);
            await _taskRepository.UpdateAsync(entity);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<TaskDto>(entity);
        }

    }
}
