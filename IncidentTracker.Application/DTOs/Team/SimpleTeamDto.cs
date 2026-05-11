using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentTracker.Application.DTOs.Team;
public class SimpleTeamDto {
    public Guid Id { get; set; }
    public string Name { get; set; } 
    public string? Description { get; set; }
}


