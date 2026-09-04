using IncidentTracker.Application.DTOs.Incidents;
using IncidentTracker.Domain.Enums;

namespace IncidentTracker.Application.DTOs.WorkOrders;
public class WorkOrderDto {

    public Guid Id { get; set; }

    public Guid IncidentId { get; set; }
    public IncidentDTO Incident { get; set; }

    public WorkOrderStatus Status { get; set; }
    public string Description { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime? StartedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
}
