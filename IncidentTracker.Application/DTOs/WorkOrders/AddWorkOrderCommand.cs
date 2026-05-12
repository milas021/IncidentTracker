namespace IncidentTracker.Application.DTOs.WorkOrders;
public class AddWorkOrderCommand {
    public Guid IncidentId { get; set; }
    public Guid? AssignedTeamId { get; set; }
    public Guid? AssignedUserId { get; set; }
    public string Description { get; set; }

}
