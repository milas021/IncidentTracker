using IncidentTracker.Domain.Enums;

namespace IncidentTracker.Domain.Entitties;
public class WorkOrder : Entity {
    public Guid Id { get; set; }

    public Guid IncidentId { get; set; }
    public Incident Incident { get; set; }

    public Guid? AssignedTeamId { get; set; }
    public Team? AssignedTeam { get; set; }

    public Guid? AssignedUserId { get; set; }
    public User? AssignedUser { get; set; }

    public WorkOrderStatus Status { get; set; } = WorkOrderStatus.Open;
    public string Description { get; set; } = default!;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? StartedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
}

