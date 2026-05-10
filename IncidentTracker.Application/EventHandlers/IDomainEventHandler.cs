using IncidentTracker.Domain.Events;

namespace IncidentTracker.Application.EventHandlers;
internal interface IDomainEventHandler<T> where T : IDomainEvent {
    Task HandleAsync(T domainEvent);
}
