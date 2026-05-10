using IncidentTracker.Application.Interfaces;
using IncidentTracker.Domain.Entitties;
using IncidentTracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace IncidentTracker.Infrastructure.Repositories;
public class AssetRepository(AppDbContext context) : IAssetRepository {
    public async Task Add(Asset asset) {
        await context.Assets.AddAsync(asset);
    }

    public async Task Delete(Guid id) {
        var asset = await Get(id);
        context.Assets.Remove(asset);
    }

    public async Task<Asset> Get(Guid id) {
        var result = await context.Assets.SingleOrDefaultAsync(x => x.Id == id);
        return result;
    }

    public async Task<IEnumerable<Asset>> GetAll() {
        var result = await context.Assets.ToListAsync();
        return result;
    }

    public async Task Save() {
        await context.SaveChangesAsync();
    }
}
