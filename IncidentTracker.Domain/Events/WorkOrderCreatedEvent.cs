namespace IncidentTracker.Domain.Events;
public record WorkOrderCreatedEvent(Guid incidentId) : IDomainEvent {
}
