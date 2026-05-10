using IncidentTracker.Domain.Events;

namespace IncidentTracker.Domain.Entitties;
public abstract class Entity {
    private List<IDomainEvent> events = new();

    public void ClearDomainEvents() {
        events.Clear();
    }

    public void AddDomainEvent(IDomainEvent domainEvent) {
        events.Add(domainEvent);
    }

    public List<IDomainEvent> GetEvents() {
        return events;
    }
}
