using IncidentTracker.Application.DTOs.Team;

namespace IncidentTracker.Application.DTOs.Users;
public class UserDto {
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Mobile { get; set; }
    public Guid? TeamId { get; set; }
    public SimpleTeamDto Team { get; set; }
}
