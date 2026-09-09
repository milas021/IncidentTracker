using IncidentTracker.Application.DTOs.WorkOrders;
using IncidentTracker.Domain.Entitties;

namespace IncidentTracker.Application.Mapper;
public static class WorkOrderMapper {
    public static WorkOrderDto ToDTO(this WorkOrder workOrder) {
        if (workOrder is null) {
            return default;
        }

        var dto = new WorkOrderDto() {
            Id = workOrder.Id,
            IncidentId = workOrder.IncidentId,
            Incident = workOrder.Incident.ToDTO(),
            AssignedTeamId = workOrder.AssignedTeamId,
            AssignedTeam = workOrder.AssignedTeam.ToSimpleDTO(),
            AssignedUserId = workOrder.AssignedUserId,
            AssignedUser = workOrder.AssignedUser.ToSimpleDTO(),
            Description = workOrder.Description,
            Status = workOrder.Status,
            CompletedAt = workOrder.CompletedAt,
            CreatedAt = workOrder.CreatedAt,
            StartedAt = workOrder.StartedAt
        };

        return dto;
    }
}
