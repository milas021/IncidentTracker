using IncidentTracker.Application.Interfaces;
using IncidentTracker.Domain.Events;
using IncidentTracker.Domain.Exceptions;

namespace IncidentTracker.Application.EventHandlers.Handlers;
internal class WorkOrderCreatedEventHandler(IIncidentRepository incidentRepository) : IDomainEventHandler<WorkOrderCreatedEvent> {
    public async Task HandleAsync(WorkOrderCreatedEvent domainEvent) {

        var incident = await incidentRepository.Get(domainEvent.incidentId);

        if (incident is null) {
            throw new AppException("Incident Not Found", 404);
        }

        incident.InProgress();

        await incidentRepository.Save();

    }
}
