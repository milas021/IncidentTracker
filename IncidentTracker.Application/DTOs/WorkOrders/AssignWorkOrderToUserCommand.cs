namespace IncidentTracker.Application.DTOs.WorkOrders;
public class AssignWorkOrderToUserCommand {
    public Guid WorkOrderId { get; set; }
    public Guid UserId { get; set; }
}
