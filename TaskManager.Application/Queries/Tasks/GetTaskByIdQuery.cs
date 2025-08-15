using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.Common;
using TaskManager.Application.DTOs.Tasks;

namespace TaskManager.Application.Queries.Tasks
{
    public record GetTaskByIdQuery(Guid Id) : IQuery<TaskDto?>;
    
}
