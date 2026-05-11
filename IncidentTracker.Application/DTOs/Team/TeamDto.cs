using IncidentTracker.Application.DTOs.Users;

namespace IncidentTracker.Application.DTOs.Team;
public class TeamDto {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }

    public ICollection<SimpleUserDto> Users { get; set; }
}
