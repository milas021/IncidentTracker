using IncidentTracker.Domain.Enums;

namespace IncidentTracker.Domain.Events;
public record IncidentAcknowledgedEvent(Guid IncidentId, IncidentStatus OldStatus, IncidentStatus NewStatus, string Description, string Actor) : IDomainEvent {


}
