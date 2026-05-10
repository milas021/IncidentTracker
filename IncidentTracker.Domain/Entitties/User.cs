namespace IncidentTracker.Domain.Entitties;
public class User : Entity {
    public Guid Id { get; set; }
    public string FullName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public Guid TeamId { get; set; }
    public Team Team { get; set; } = default!;
}

