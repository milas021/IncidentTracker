using IncidentTracker.Domain.Entitties;

namespace IncidentTracker.Application.Interfaces;
public interface ITeamRepository : IRepository {
    Task Add(Team team);
    Task<IEnumerable<Team>> GetAll();
    Task<Team> Get(Guid id);

}
