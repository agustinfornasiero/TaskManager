

using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata;
using TaskManager.Application.Commands.Tasks;
using TaskManager.Application.DTOs.Tasks;
using TaskManager.Core.Interfaces;

namespace TaskManager.Application.Handlers.Commands.Tasks
{
    internal class UpdateTaskHandler : IRequestHandler<UpdateTaskCommand, TaskDto>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateTaskHandler(ITaskRepository taskRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<TaskDto> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var entity = await _taskRepository.GetByIdAsync(request.Id, cancellationToken);

            if (entity == null) throw new KeyNotFoundException("Task Not Found");

            _mapper.Map(request.Task, entity);

            await _taskRepository.UpdateAsync(entity);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<TaskDto>(entity);
        }
    }
}
