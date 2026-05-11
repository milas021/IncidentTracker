using IncidentTracker.Domain.Entitties;

namespace IncidentTracker.Application.Interfaces;
public interface IUserRepository : IRepository {
    Task Add(User user);
    Task<IEnumerable<User>> GetAll();
    Task<User> Get(Guid id);
}
