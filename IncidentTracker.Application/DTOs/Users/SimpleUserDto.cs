namespace IncidentTracker.Application.DTOs.Users;
public class SimpleUserDto {
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Mobile { get; set; }
}
