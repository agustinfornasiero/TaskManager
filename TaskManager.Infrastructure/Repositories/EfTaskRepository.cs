
using Microsoft.EntityFrameworkCore;
using TaskManager.Core.Entities;
using TaskManager.Core.Interfaces;
using TaskManager.Infrastructure.Persistence;

namespace TaskManager.Infrastructure.Repositories
{
    public class EfTaskRepository : ITaskRepository
    {
        private readonly AppDbContext _ctx;

        public EfTaskRepository(AppDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task AddAsync(TaskItem task, CancellationToken ct = default)
            => await _ctx.Tasks.AddAsync(task, ct);

        public async Task DeleteAsync(Guid id, CancellationToken ct = default)
        {
            var t = await _ctx.Tasks.FindAsync(new object[] { id }, ct);

            if (t != null)
                _ctx.Tasks.Remove(t);
        }

        public async Task<IReadOnlyList<TaskItem>> GetAllAsync(CancellationToken ct = default)
            => await _ctx.Tasks.AsNoTracking().Include(t => t.Events).ToListAsync(ct);

        public async Task<TaskItem> GetByIdAsync(Guid id, CancellationToken ct = default)
            => await _ctx.Tasks.Include(t => t.Events).FirstOrDefaultAsync(t => t.Id == id, ct);


        public Task UpdateAsync(TaskItem task, CancellationToken ct = default)
        {
            _ctx.Tasks.Update(task);
            return Task.CompletedTask;
        }
    }
}
