using IncidentTracker.Application.DTOs.WorkOrders;
using IncidentTracker.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace IncidentTracker.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class WorkOrdersController(WorkOrderService workOrderService) : ControllerBase {

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id) {
        var result = await workOrderService.Get(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(AddWorkOrderCommand command) {
        await workOrderService.Add(command);
        return NoContent();
    }

    [HttpPut("{id}/assign-team")]
    public async Task<IActionResult> AssignToTeam(Guid id, AssignWorkOrderToTeamCommand command) {
        await workOrderService.AssignWorkOrderToTeam(id, command);
        return NoContent();
    }

    [HttpPut("{id}/assign-user")]
    public async Task<IActionResult> AssignToUser(Guid id, AssignWorkOrderToUserCommand command) {
        await workOrderService.AssignWorkOrderToUser(id, command);
        return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllWorkOrder()
    {
        var result = await workOrderService.GetAllWorkOrder();
        return Ok(result);
    }
        
}
