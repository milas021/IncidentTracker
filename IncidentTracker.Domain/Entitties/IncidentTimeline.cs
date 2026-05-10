using IncidentTracker.Domain.Enums;

namespace IncidentTracker.Domain.Entitties;
public class IncidentTimeline : Entity {
    private IncidentTimeline() { }
    public Guid Id { get; private set; }
    public Guid IncidentId { get; private set; }
    public Incident Incident { get; private set; }

    public IncidentStatus OldStatus { get; private set; }
    public IncidentStatus NewStatus { get; private set; }
    public DateTime ChangedAt { get; private set; }
    public string ChangedBy { get; private set; }
    public string? Description { get; private set; }


    public IncidentTimeline(Guid incidentId, IncidentStatus oldStatus, IncidentStatus newStatus, string description, string actor = "system") {
        Id = Guid.NewGuid();
        IncidentId = incidentId;
        OldStatus = oldStatus;
        NewStatus = newStatus;
        ChangedAt = DateTime.UtcNow;
        ChangedBy = actor;
        Description = description;

    }
}
