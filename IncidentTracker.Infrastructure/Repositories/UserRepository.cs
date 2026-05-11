using IncidentTracker.Application.Interfaces;
using IncidentTracker.Domain.Entitties;
using IncidentTracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace IncidentTracker.Infrastructure.Repositories;
public class UserRepository(AppDbContext context) : IUserRepository {
    public async Task Add(User user) {
        await context.Users.AddAsync(user);
    }

    public async Task<User> Get(Guid id) {
        var result = await context.Users.SingleOrDefaultAsync(x => x.Id == id);
        return result;
    }

    public async Task<IEnumerable<User>> GetAll() {
        var result = await context.Users.ToListAsync();
        return result;
    }

    public async Task Save() {
        await context.SaveChangesAsync();
    }
}
