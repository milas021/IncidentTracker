using IncidentTracker.Application.DTOs.Team;
using IncidentTracker.Application.Interfaces;
using IncidentTracker.Application.Mapper;
using IncidentTracker.Domain.Entitties;

namespace IncidentTracker.Application.Services;
public class TeamService(ITeamRepository teamRepository, IUserRepository userRepository) {

    public async Task Add(AddTeamCommand command) {
        var team = new Team(command.Name, command.Description);
        await teamRepository.Add(team);
        await teamRepository.Save();
    }

    public async Task<IEnumerable<TeamDto>> GetAll() {
        var result = await teamRepository.GetAll();
        var dto = result.Select(x => x.ToDTO());
        return dto;

    }

    public async Task<TeamDto> Get(Guid id) {
        var team = await teamRepository.Get(id);
        var result = team.ToDTO();
        return result;
    }


    public async Task AddMemberToTeam(Guid teemId, AddMemberToTeamCommand command) {
        var team = await teamRepository.Get(teemId);
        var users = new List<User>();
        foreach (var id in command.MemberIds) {
            var user = await userRepository.Get(id);
            users.Add(user);
        }
        team.SetMembers(users);
        await teamRepository.Save();
    }

}
