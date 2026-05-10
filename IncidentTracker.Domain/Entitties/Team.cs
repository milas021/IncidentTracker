namespace IncidentTracker.Domain.Entitties;
public class Team : Entity {
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }

    public ICollection<User> Users { get; set; } = new List<User>();
    public ICollection<WorkOrder> WorkOrders { get; set; } = new List<WorkOrder>();
}

