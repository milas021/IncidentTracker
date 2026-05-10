using IncidentTracker.Domain.Entitties;
using IncidentTracker.Domain.Enums;
using IncidentTracker.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IncidentTracker.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class WorkOrdersController : ControllerBase {
    private readonly AppDbContext _db;
    public WorkOrdersController(AppDbContext db) => _db = db;

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
        => Ok(await _db.WorkOrders
            .Include(w => w.AssignedTeam)
            .Include(w => w.AssignedUser)
            .FirstOrDefaultAsync(w => w.Id == id));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] WorkOrder wo) {
        _db.WorkOrders.Add(wo);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = wo.Id }, wo);
    }

    [HttpPut("{id}/assign")]
    public async Task<IActionResult> Assign(Guid id, Guid? teamId, Guid? userId) {
        var wo = await _db.WorkOrders.FindAsync(id);
        if (wo is null) {
            return NotFound();
        }

        wo.AssignedTeamId = teamId;
        wo.AssignedUserId = userId;
        wo.Status = WorkOrderStatus.Assigned;

        await _db.SaveChangesAsync();
        return NoContent();
    }
}

