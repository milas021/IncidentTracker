using IncidentTracker.Domain.Enums;
using IncidentTracker.Domain.Exceptions;

namespace IncidentTracker.Domain.Entitties;
public class WorkOrder : Entity {
    private WorkOrder() { }
    public Guid Id { get; set; }

    public Guid IncidentId { get; set; }
    public Incident Incident { get; set; }

    public Guid? AssignedTeamId { get; set; }
    public Team? AssignedTeam { get; set; }

    public Guid? AssignedUserId { get; set; }
    public User? AssignedUser { get; set; }

    public WorkOrderStatus Status { get; set; }
    public string Description { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime? StartedAt { get; set; }
    public DateTime? CompletedAt { get; set; }


    public WorkOrder(Guid incidentId) {
        Id = Guid.NewGuid();
        IncidentId = incidentId;
        Status = WorkOrderStatus.Open;
        CreatedAt = DateTime.UtcNow;
    }

    public WorkOrder AssignUser(Guid? userId) {
        if (Status != WorkOrderStatus.Open && Status != WorkOrderStatus.Assigned) {
            throw new AppException("Invalid Operation");
        }
        if (userId is null) {
            return this;
        }

        AssignedUserId = userId;
        Status = WorkOrderStatus.Assigned;
        return this;
    }

    public WorkOrder AssignTeam(Guid? teamId) {
        if (Status != WorkOrderStatus.Open && Status != WorkOrderStatus.Assigned) {
            throw new AppException("Invalid Operation");
        }
        if (teamId is null) {
            return this;
        }

        AssignedTeamId = teamId;
        Status = WorkOrderStatus.Assigned;
        return this;
    }

    public WorkOrder SetDescription(string description) {
        Description = description;
        return this;
    }

    public void StartWorkOrder() {
        if (Status != WorkOrderStatus.Assigned) {
            throw new AppException("Invalid Operation");
        }
        Status = WorkOrderStatus.InProgress;
        StartedAt = DateTime.UtcNow;
    }

    public void CompleteWorkOrder() {
        if (Status != WorkOrderStatus.InProgress) {
            throw new AppException("Invalid Operation");
        }
        Status = WorkOrderStatus.Done;
        CompletedAt = DateTime.UtcNow;
    }
}

