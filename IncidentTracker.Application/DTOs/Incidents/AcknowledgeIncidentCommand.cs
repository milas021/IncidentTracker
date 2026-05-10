using IncidentTracker.Domain.Enums;

namespace IncidentTracker.Application.DTOs.Incidents;
public class AcknowledgeIncidentCommand {
    public IncidentPriority Priority { get; set; }
    public string Description { get; set; }
}
