using IncidentTracker.Application.DTOs.Assets;
using IncidentTracker.Domain.Enums;

namespace IncidentTracker.Application.DTOs.Incidents;
public class IncidentDTO {

    public Guid Id { get; set; }
    public Guid AssetId { get; set; }
    public AssetDTO Asset { get; set; }

    public string Title { get; set; }
    public string Description { get; set; }
    public IncidentPriority Severity { get; set; }
    public IncidentStatus Status { get; set; }

    public DateTime ReportedAt { get; set; }
    public DateTime? AcknowledgedAt { get; set; }
    public DateTime? ResolvedAt { get; set; }
    public DateTime? ClosedAt { get; set; }
}
