using IncidentTracker.Application.DTOs.Incidents;
using IncidentTracker.Application.EventHandlers;
using IncidentTracker.Application.Interfaces;
using IncidentTracker.Application.Mapper;
using IncidentTracker.Domain.Entitties;

namespace IncidentTracker.Application.Services;
public class IncidentService(IIncidentRepository incidentRepository, DomainEventDispatcher eventDispatcher) {

    public async Task AddIncident(AddIncidentCommand command) {
        var incident = new Incident(command.AssetId, command.Title, command.Description);
        await incidentRepository.Add(incident);
        await incidentRepository.Save();
    }

    public async Task<IEnumerable<IncidentDTO>> GetAll() {
        var data = await incidentRepository.GetAll();
        var result = data.Select(x => x.ToDTO()).ToList();
        return result;
    }

    public async Task<IncidentDTO> Get(Guid id) {
        var data = await incidentRepository.Get(id);
        var result = data.ToDTO();
        return result;

    }

    public async Task Acknowledge(Guid id, string actor, AcknowledgeIncidentCommand command) {
        var incident = await incidentRepository.Get(id);
        incident.Acknowledge(command.Priority, actor, command.Description);
        await incidentRepository.Save();

        //var domainEvents = incident.GetEvents();
        //await eventDispatcher.DispatchAsync(domainEvents);
        //incident.ClearDomainEvents();
    }

}
