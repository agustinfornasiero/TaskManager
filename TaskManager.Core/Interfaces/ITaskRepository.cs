using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Entities;

namespace TaskManager.Core.Interfaces
{
    public interface ITaskRepository
    {
        Task<TaskItem> GetByIdAsync(Guid id, CancellationToken ct = default);

        Task<IReadOnlyList<TaskItem>> GetAllAsync(CancellationToken ct = default);

        Task AddAsync(TaskItem task, CancellationToken ct = default);

        Task UpdateAsync(TaskItem task, CancellationToken ct = default);

        Task DeleteAsync(Guid id, CancellationToken ct = default);
    }
}
