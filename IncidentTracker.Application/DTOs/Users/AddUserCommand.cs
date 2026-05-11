namespace IncidentTracker.Application.DTOs.Users;
public class AddUserCommand {
    public string FullName { get; set; }
    public string? Email { get; set; }
    public string Mobile { get; set; }
    public Guid? TeamId { get; set; }
}
