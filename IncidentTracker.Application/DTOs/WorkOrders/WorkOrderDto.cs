using IncidentTracker.Application.DTOs.Incidents;
using IncidentTracker.Application.DTOs.Team;
using IncidentTracker.Application.DTOs.Users;
using IncidentTracker.Domain.Enums;

namespace IncidentTracker.Application.DTOs.WorkOrders;
public class WorkOrderDto {

    public Guid Id { get; set; }

    public Guid IncidentId { get; set; }
    public IncidentDTO Incident { get; set; }

    public Guid? AssignedTeamId { get; set; }
    public SimpleTeamDto AssignedTeam { get; set; }

    public Guid? AssignedUserId { get; set; }
    public SimpleUserDto AssignedUser { get; set; }

    public WorkOrderStatus Status { get; set; }
    public string Description { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime? StartedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
}
