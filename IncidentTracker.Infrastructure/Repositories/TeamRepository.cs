using IncidentTracker.Application.Interfaces;
using IncidentTracker.Domain.Entitties;
using IncidentTracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace IncidentTracker.Infrastructure.Repositories;
internal class TeamRepository(AppDbContext context) : ITeamRepository {
    public async Task Add(Team team) {
        await context.Teams.AddAsync(team);
    }

    public async Task<Team> Get(Guid id) {
        var result = await context.Teams
            .Include(x => x.Users)
            .SingleOrDefaultAsync(x => x.Id == id);
        return result;
    }

    public async Task<IEnumerable<Team>> GetAll() {
        var result = await context.Teams
            .Include(x => x.Users)
            .ToListAsync();
        return result;
    }

    public async Task Save() {
        await context.SaveChangesAsync();
    }
}
