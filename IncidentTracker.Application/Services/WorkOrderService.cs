using IncidentTracker.Application.DTOs.WorkOrders;
using IncidentTracker.Application.Interfaces;
using IncidentTracker.Domain.Entitties;

namespace IncidentTracker.Application.Services;
public class WorkOrderService(IWorkOrderRepository workOrderRepository) {

    public async Task Add(AddWorkOrderCommand command) {
        var workOrder = new WorkOrder(command.IncidentId)
            .SetDescription(command.Description)
            .AssignTeam(command.AssignedTeamId)
            .AssignUser(command.AssignedUserId);

        await workOrderRepository.Add(workOrder);
        await workOrderRepository.Save();
    }

    public async Task<IEnumerable>

}
