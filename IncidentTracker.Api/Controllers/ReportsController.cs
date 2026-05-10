using IncidentTracker.Application.DTOs;
using IncidentTracker.Domain.Entitties;
using IncidentTracker.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IncidentTracker.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ReportsController : ControllerBase {
    private readonly AppDbContext _db;
    public ReportsController(AppDbContext db) => _db = db;

    [HttpPost("mttr")]
    public async Task<IActionResult> MTTR([FromBody] ReportRequest req) {
        var incidents = await _db.Incidents
            .Where(i => i.ReportedAt >= req.From && i.ReportedAt <= req.To)
            .Where(i => i.ResolvedAt != null)
            .ToListAsync();

        if (!incidents.Any()) {
            return Ok(new MTTRResponse(0));
        }

        var avgHours = incidents
            .Average(i => (i.ResolvedAt!.Value - i.ReportedAt).TotalHours);

        return Ok(new MTTRResponse(Math.Round(avgHours, 2)));
    }

    [HttpPost("mtbf")]
    public async Task<IActionResult> MTBF([FromBody] ReportRequest req) {
        var incidents = await _db.Incidents
            .Where(i => i.ReportedAt >= req.From && i.ReportedAt <= req.To)
            .OrderBy(i => i.AssetId)
            .ThenBy(i => i.ReportedAt)
            .ToListAsync();

        if (!incidents.Any()) {
            return Ok(new MTBFResponse(0));
        }

        var gaps = incidents
            .GroupBy(i => i.AssetId)
            .SelectMany(g => {
                var list = g.ToList();
                var diffs = new List<double>();
                for (int i = 1; i < list.Count; i++) {
                    diffs.Add((list[i].ReportedAt - list[i - 1].ReportedAt).TotalHours);
                }
                return diffs;
            })
            .ToList();

        if (!gaps.Any()) {
            return Ok(new MTBFResponse(0));
        }

        var avgHours = gaps.Average();
        return Ok(new MTBFResponse(Math.Round(avgHours, 2)));
    }


    // -------- MTBF by Team --------
    [HttpPost("mtbf/team")]
    public async Task<IActionResult> MTBFByTeam([FromBody] TeamReportRequest req) {
        var incidents = await _db.WorkOrders
            .Where(w => w.AssignedTeamId == req.TeamId)
            .Where(w => w.Incident.ReportedAt >= req.From && w.Incident.ReportedAt <= req.To)
            .Select(w => w.Incident)
            .Distinct()
            .OrderBy(i => i.AssetId)
            .ThenBy(i => i.ReportedAt)
            .ToListAsync();

        return Ok(new MTBFResponse(CalcMtbfHours(incidents)));
    }

    // -------- MTBF by User --------
    [HttpPost("mtbf/user")]
    public async Task<IActionResult> MTBFByUser([FromBody] UserReportRequest req) {
        var incidents = await _db.WorkOrders
            .Where(w => w.AssignedUserId == req.UserId)
            .Where(w => w.Incident.ReportedAt >= req.From && w.Incident.ReportedAt <= req.To)
            .Select(w => w.Incident)
            .Distinct()
            .OrderBy(i => i.AssetId)
            .ThenBy(i => i.ReportedAt)
            .ToListAsync();

        return Ok(new MTBFResponse(CalcMtbfHours(incidents)));
    }

    // ---- helper ----
    private static double CalcMtbfHours(List<Incident> incidents) {
        if (!incidents.Any()) {
            return 0;
        }

        var gaps = incidents
            .GroupBy(i => i.AssetId)
            .SelectMany(g => {
                var list = g.ToList();
                var diffs = new List<double>();
                for (int i = 1; i < list.Count; i++) {
                    diffs.Add((list[i].ReportedAt - list[i - 1].ReportedAt).TotalHours);
                }
                return diffs;
            })
            .ToList();

        if (!gaps.Any()) {
            return 0;
        }

        return Math.Round(gaps.Average(), 2);
    }
}

