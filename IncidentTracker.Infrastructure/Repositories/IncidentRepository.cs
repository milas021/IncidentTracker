using IncidentTracker.Application.Interfaces;
using IncidentTracker.Domain.Entitties;
using IncidentTracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace IncidentTracker.Infrastructure.Repositories;
public class IncidentRepository(AppDbContext context) : IIncidentRepository {
    public async Task Add(Incident incident) {
        await context.Incidents.AddAsync(incident);
    }

    public async Task Delete(Guid id) {
        var incident = await Get(id);
        context.Incidents.Remove(incident);
    }

    public async Task<Incident> Get(Guid id) {
        var result = await context.Incidents
            .Include(x => x.Asset)
            .SingleOrDefaultAsync(x => x.Id == id);

        return result;
    }

    public async Task<IEnumerable<Incident>> GetAll() {
        var result = await context.Incidents.ToListAsync();
        return result;
    }

    public async Task Save() {
        await context.SaveChangesAsync();
    }
}
