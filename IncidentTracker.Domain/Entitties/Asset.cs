using IncidentTracker.Domain.Enums;

namespace IncidentTracker.Domain.Entitties;
public class Asset : Entity {
    private Asset() { }
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Code { get; private set; }
    public AssetType Type { get; private set; }
    public string? Location { get; private set; }
    public DateTime? InstalledAt { get; private set; }

    public ICollection<Incident> Incidents { get; private set; } = new List<Incident>();

    public Asset(string name, string code, AssetType type) {
        Id = Guid.NewGuid();
        Code = code;
        Type = type;
        Name = name;
    }
    public Asset WithLocation(string? location) {
        if (location is null) {
            return this;
        }

        Location = location;
        return this;
    }
    public Asset WithInstalledDate(DateTime? installedAt) {
        if (installedAt is null) {
            return this;
        }

        InstalledAt = installedAt;
        return this;
    }

    public Asset Edit(string name, string code, AssetType type) {
        Code = code;
        Name = name;
        Type = type;
        return this;
    }
}
