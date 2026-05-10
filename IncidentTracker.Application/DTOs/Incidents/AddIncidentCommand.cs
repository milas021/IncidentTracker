namespace IncidentTracker.Application.DTOs.Incidents;
public class AddIncidentCommand {
    public Guid AssetId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

}
