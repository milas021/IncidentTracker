using IncidentTracker.Domain.Entitties;

namespace IncidentTracker.Application.Interfaces;
public interface IIncidentRepository : IRepository {
    Task Add(Incident incident);
    Task<IEnumerable<Incident>> GetAll();
    Task<Incident> Get(Guid id);
    Task Delete(Guid id);
}
