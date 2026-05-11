using IncidentTracker.Application.DTOs.Team;
using IncidentTracker.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace IncidentTracker.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TeamController(TeamService teamService) : AppController {

    [HttpPost]
    public async Task<IActionResult> Add(AddTeamCommand command) {
        await teamService.Add(command);
        return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() {
        var result = await teamService.GetAll();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id) {
        var result = await teamService.Get(id);
        return Ok(result);
    }

    [HttpPost("{id}")]
    public async Task<IActionResult> AddMemberToTeam(Guid id, AddMemberToTeamCommand command) {
        await teamService.AddMemberToTeam(id, command);
        return NoContent();
    }


}
