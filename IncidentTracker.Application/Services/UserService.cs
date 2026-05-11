using IncidentTracker.Application.DTOs.Users;
using IncidentTracker.Application.Interfaces;
using IncidentTracker.Application.Mapper;
using IncidentTracker.Domain.Entitties;

namespace IncidentTracker.Application.Services;
public class UserService(IUserRepository userRepository) {
    public async Task Add(AddUserCommand command) {
        var user = new User(command.FullName, command.Mobile)
            .SetEmail(command.Email)
            .SetTeamId(command.TeamId);

        await userRepository.Add(user);
        await userRepository.Save();
    }

    public async Task<IEnumerable<UserDto>> GetAll() {
        var result = await userRepository.GetAll();
        var dtos = result.Select(x => x.ToDTO());
        return dtos;
    }
}
