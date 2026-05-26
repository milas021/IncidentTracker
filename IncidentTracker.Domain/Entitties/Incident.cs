using IncidentTracker.Domain.Enums;
using IncidentTracker.Domain.Events;
using IncidentTracker.Domain.Exceptions;

namespace IncidentTracker.Domain.Entitties;
public class Incident : Entity {
    private Incident() { }
    public Guid Id { get; private set; }
    public Guid AssetId { get; private set; }
    public Asset Asset { get; private set; }

    public string Title { get; private set; }
    public string Description { get; private set; }
    public IncidentPriority Priority { get; private set; }
    public IncidentStatus Status { get; private set; }

    public DateTime ReportedAt { get; private set; }
    public DateTime? AcknowledgedAt { get; private set; }
    public DateTime? ResolvedAt { get; private set; }
    public DateTime? ClosedAt { get; private set; }

    public ICollection<IncidentTimeline> Timeline { get; private set; } = new List<IncidentTimeline>();
    public ICollection<WorkOrder> WorkOrders { get; private set; } = new List<WorkOrder>();

    public Incident(Guid assetId, string title, string description) {
        Id = Guid.NewGuid();
        AssetId = assetId;
        Title = title;
        Description = description;
        Status = IncidentStatus.Reported;
        ReportedAt = DateTime.UtcNow;
    }

    public void Acknowledge(IncidentPriority priority, string actor, string description) {
        if (this.Status != IncidentStatus.Reported) {
            throw new AppException("Invalid Operation");
        }
        var oldStatus = this.Status;

        Priority = priority;

        Status = IncidentStatus.Acknowledged;

        var newStatus = this.Status;

        AcknowledgedAt = DateTime.UtcNow;

        AddDomainEvent(new IncidentAcknowledgedEvent(this.Id, oldStatus, newStatus, description, actor));

    }

    public void InProgress() {
        if (Status != IncidentStatus.Acknowledged) {
            throw new AppException("Invalid Operation");
        }

        Status = IncidentStatus.InProgress;
    }
}

