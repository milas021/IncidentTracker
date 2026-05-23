using IncidentTracker.Application.DTOs.WorkOrders;
using IncidentTracker.Domain.Entitties;

namespace IncidentTracker.Application.Mapper;
public static class WorkOrderMapper {
    public static WorkOrderDto ToDTO(this WorkOrder workOrder) {
        var dto = new WorkOrderDto() {
            Id = workOrder.Id,
            IncidentId = workOrder.IncidentId,
            Incident = workOrder.Incident.ToDTO(),
            Description = workOrder.Description,
            Status = workOrder.Status,
            CompletedAt = workOrder.CompletedAt,
            CreatedAt = workOrder.CreatedAt,
            StartedAt = workOrder.StartedAt
        };

        return dto;
    }
}
