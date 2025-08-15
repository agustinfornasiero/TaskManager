
using AutoMapper;
using MediatR;
using TaskManager.Application.DTOs.Tasks;
using TaskManager.Application.Queries.Tasks;
using TaskManager.Core.Interfaces;

namespace TaskManager.Application.Handlers.Queries.Tasks
{
    internal class GetTaskByIdHandler : IRequestHandler<GetTaskByIdQuery, TaskDto?>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public GetTaskByIdHandler(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<TaskDto?> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetByIdAsync(request.Id, cancellationToken);
            
            return task == null ? null : _mapper.Map<TaskDto>(task);

        }
    }
}
