using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Entities;
using TaskManager.Core.Interfaces;
using TaskManager.Infrastructure.Persistence;

namespace TaskManager.Infrastructure.Repositories
{
    public class EfUserRepository : IUserRepository
    {

        private readonly AppDbContext _ctx;

        public EfUserRepository(AppDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task AddAsync(User user, CancellationToken ct = default) 
            => await _ctx.Users.AddAsync(user, ct);

        public async Task DeleteAsync(Guid id, CancellationToken ct = default)
        {
            var u = await _ctx.Users.FindAsync(new object[] { id }, ct);
            if (u != null)
                _ctx.Users.Remove(u);
        }

        public async Task<IReadOnlyList<User>> GetAllAsync(CancellationToken ct = default)
            => await _ctx.Users.AsNoTracking().ToListAsync(ct);

        public async Task<User?> GetByEmailAsync(string email, CancellationToken ct = default)
            => await _ctx.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email, ct);

        public async Task<User?> GetByIdAsync(Guid id, CancellationToken ct = default)
            => await _ctx.Users.FindAsync(new object[] { id }, ct);

        public Task UpdateAsync(User user, CancellationToken ct = default)
        {
            _ctx.Users.Update(user);
            return Task.CompletedTask;
        }
    }
}
