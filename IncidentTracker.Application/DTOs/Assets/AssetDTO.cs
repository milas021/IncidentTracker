using IncidentTracker.Domain.Enums;

namespace IncidentTracker.Application.DTOs.Assets;
public class AssetDTO {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public AssetType Type { get; set; }
    public string? Location { get; set; }
    public DateTime? InstalledAt { get; set; }
}
