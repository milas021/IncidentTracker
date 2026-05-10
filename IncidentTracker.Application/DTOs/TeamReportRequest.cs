namespace IncidentTracker.Application.DTOs;
public record TeamReportRequest(Guid TeamId, DateTime From, DateTime To);
