using IncidentTracker.Application.Interfaces;
using IncidentTracker.Domain.Entitties;
using IncidentTracker.Infrastructure.Data;

namespace IncidentTracker.Infrastructure.Repositories;
internal class IncidentTimelineRepository(AppDbContext context) : IIncidentTimelineRepository {
    public async Task Add(IncidentTimeline incidentTimeline) {
        await context.IncidentTimelines.AddAsync(incidentTimeline);
    }

    public async Task Save() {
        await context.SaveChangesAsync();
    }
}
