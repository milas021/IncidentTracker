using IncidentTracker.Application.DTOs.Assets;
using IncidentTracker.Domain.Entitties;

namespace IncidentTracker.Application.Mapper;
public static class AssetMapper {
    public static AssetDTO ToDTO(this Asset asset) {
        var result = new AssetDTO() {
            Id = asset.Id,
            Name = asset.Name,
            Code = asset.Code,
            InstalledAt = asset.InstalledAt,
            Location = asset.Location,
            Type = asset.Type
        };
        return result;
    }
}
