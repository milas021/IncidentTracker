namespace IncidentTracker.Application.DTOs.WorkOrders;
public class AssignWorkOrderToTeamCommand {
    public Guid WorkOrderId { get; set; }
    public Guid TeamId { get; set; }
}
