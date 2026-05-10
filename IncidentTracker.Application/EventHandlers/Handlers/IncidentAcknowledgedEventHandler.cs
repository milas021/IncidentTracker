using IncidentTracker.Application.Interfaces;
using IncidentTracker.Domain.Entitties;
using IncidentTracker.Domain.Events;

namespace IncidentTracker.Application.EventHandlers.Handlers;
internal class IncidentAcknowledgedEventHandler : IDomainEventHandler<IncidentAcknowledgedEvent> {
    private readonly IIncidentTimelineRepository _timelineRepository;

    public IncidentAcknowledgedEventHandler(IIncidentTimelineRepository timelineRepository) {
        _timelineRepository = timelineRepository;
    }

    public async Task HandleAsync(IncidentAcknowledgedEvent domainEvent) {
        var timeline = new IncidentTimeline(domainEvent.IncidentId, domainEvent.OldStatus, domainEvent.NewStatus, domainEvent.Description, domainEvent.Actor);

        await _timelineRepository.Add(timeline);
        await _timelineRepository.Save();
    }
}

