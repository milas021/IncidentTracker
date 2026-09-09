using IncidentTracker.Domain.Entitties;

namespace IncidentTracker.Application.Interfaces;
public interface IWorkOrderRepository : IRepository {
    Task Add(WorkOrder workOrder);
    Task<IEnumerable<WorkOrder>> GetByUserId(Guid UserId);
    Task<IEnumerable<WorkOrder>> GetByTeamId(Guid teamId);
    Task<WorkOrder> GetById(Guid id);
    Task<IEnumerable<WorkOrder>> GetAll();
}
