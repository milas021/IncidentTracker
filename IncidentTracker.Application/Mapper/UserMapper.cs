using IncidentTracker.Application.DTOs.Users;
using IncidentTracker.Domain.Entitties;

namespace IncidentTracker.Application.Mapper;
public static class UserMapper {
    public static UserDto ToDTO(this User user) {
        if (user is null) {
            return default;
        }

        var dto = new UserDto {
            Id = user.Id,
            FullName = user.FullName,
            Mobile = user.Mobile,
            Email = user.Email,
            TeamId = user.TeamId,
            Team = user.Team.ToSimpleDTO(),

        };
        return dto;
    }

    public static SimpleUserDto ToSimpleDTO(this User user) {
        if (user is null) {
            return default;
        }

        var dto = new SimpleUserDto {
            Id = user.Id,
            FullName = user.FullName,
            Mobile = user.Mobile,
            Email = user.Email,

        };
        return dto;
    }
}
