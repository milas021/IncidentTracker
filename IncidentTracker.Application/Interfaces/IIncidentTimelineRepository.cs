using IncidentTracker.Domain.Entitties;

namespace IncidentTracker.Application.Interfaces;
public interface IIncidentTimelineRepository : IRepository {
    Task Add(IncidentTimeline incidentTimeline);
}
