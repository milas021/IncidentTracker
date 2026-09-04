using IncidentTracker.Application.DTOs.Incidents;
using IncidentTracker.Domain.Entitties;

namespace IncidentTracker.Application.Mapper;
public static class IncidentMapper {
    public static IncidentDTO ToDTO(this Incident incident) {
        if (incident is null) {
            return default;
        }

        var dto = new IncidentDTO() {
            AcknowledgedAt = DateTime.Now,
            AssetId = incident.AssetId,
            Asset = incident.Asset?.ToDTO(),
            ClosedAt = DateTime.Now,
            Description = incident.Description,
            Id = incident.Id,
            ReportedAt = incident.ReportedAt,
            ResolvedAt = incident.ResolvedAt,
            Priority = incident.Priority,
            Status = incident.Status,
            Title = incident.Title
        };
        return dto;
    }
}
