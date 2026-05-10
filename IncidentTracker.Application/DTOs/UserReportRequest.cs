namespace IncidentTracker.Application.DTOs;
public record UserReportRequest(Guid UserId, DateTime From, DateTime To);