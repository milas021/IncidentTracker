using IncidentTracker.Application.Interfaces;
using IncidentTracker.Domain.Entitties;
using IncidentTracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace IncidentTracker.Infrastructure.Repositories;
internal class WorkOrderRepository(AppDbContext context) : IWorkOrderRepository {
    public async Task Add(WorkOrder workOrder) {
        await context.WorkOrders.AddAsync(workOrder);
    }

    public async Task<WorkOrder> GetById(Guid id) {

        var result = await context.WorkOrders.SingleOrDefaultAsync(x => x.Id == id);
        return result;
    }

    public async Task<IEnumerable<WorkOrder>> GetByTeamId(Guid teamId) {

        var result = await context.WorkOrders.Where(x => x.AssignedTeamId == teamId).ToListAsync();
        return result;
    }

    public async Task<IEnumerable<WorkOrder>> GetByUserId(Guid UserId) {
        var result = await context.WorkOrders.Where(x => x.AssignedUserId == UserId).ToListAsync();
        return result;
    }

    public async Task Save() {
        await context.SaveChangesAsync();
    }
}
