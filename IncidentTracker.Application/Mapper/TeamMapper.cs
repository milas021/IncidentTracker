using IncidentTracker.Application.DTOs.Team;
using IncidentTracker.Domain.Entitties;

namespace IncidentTracker.Application.Mapper;
public static class TeamMapper {
    public static SimpleTeamDto ToSimpleDTO(this Team team) {
        if (team is null) {
            return default;
        }

        var dto = new SimpleTeamDto {
            Id = team.Id,
            Name = team.Name,
            Description = team.Description
        };

        return dto;
    }

    public static TeamDto ToDTO(this Team team) {
        if (team is null) {
            return default;
        }

        var dto = new TeamDto {
            Id = team.Id,
            Name = team.Name,
            Description = team.Description,
            Users = team.Users.Select(x => x.ToSimpleDTO()).ToList(),
        };
        return dto;

    }
}
