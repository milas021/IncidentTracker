using IncidentTracker.Domain.Entitties;

namespace IncidentTracker.Application.Interfaces;
public interface IAssetRepository : IRepository {
    Task Add(Asset asset);
    Task<IEnumerable<Asset>> GetAll();
    Task<Asset> Get(Guid id);
    Task Delete(Guid id);
}
