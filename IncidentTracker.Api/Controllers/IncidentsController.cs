using IncidentTracker.Application.DTOs.Incidents;
using IncidentTracker.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace IncidentTracker.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class IncidentsController(IncidentService incidentService) : ControllerBase {


    [HttpGet]
    public async Task<IActionResult> GetAll() {
        var result = await incidentService.GetAll();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add(AddIncidentCommand command) {
        await incidentService.AddIncident(command);
        return NoContent();

    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id) {
        var result = await incidentService.Get(id);
        return Ok(result);
    }

    [HttpPut("{id}/Acknowledge")]
    public async Task<IActionResult> Acknowledge(Guid id, AcknowledgeIncidentCommand command) {

        await incidentService.Acknowledge(id, "developer", command);
        return NoContent();
    }
}
