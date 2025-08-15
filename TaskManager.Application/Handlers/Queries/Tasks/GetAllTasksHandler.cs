
using AutoMapper;
using MediatR;
using TaskManager.Application.DTOs.Tasks;
using TaskManager.Application.Queries.Tasks;
using TaskManager.Core.Interfaces;

namespace TaskManager.Application.Handlers.Queries.Tasks
{
    internal class GetAllTasksHandler : IRequestHandler<GetAllTasksQuery, IEnumerable<TaskDto>>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public GetAllTasksHandler(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TaskDto>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _taskRepository.GetAllAsync(cancellationToken);

            return _mapper.Map<IEnumerable<TaskDto>>(tasks);
        }
    }
}
