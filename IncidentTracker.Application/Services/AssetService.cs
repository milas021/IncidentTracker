using IncidentTracker.Application.DTOs.Assets;
using IncidentTracker.Application.Interfaces;
using IncidentTracker.Application.Mapper;
using IncidentTracker.Domain.Entitties;

namespace IncidentTracker.Application.Services;
public class AssetService(IAssetRepository assetRepository) {

    public async Task AddAsset(AddAssetCommand command) {
        var asset = new Asset(command.Name, command.Code, command.Type)
            .WithLocation(command.Location)
            .WithInstalledDate(command.InstalledAt);

        await assetRepository.Add(asset);
        await assetRepository.Save();
    }

    public async Task<IEnumerable<AssetDTO>> GetAll() {
        var result = await assetRepository.GetAll();
        var dtos = result.Select(x => x.ToDTO());
        return dtos;
    }

    public async Task Edit(Guid id, EditAssetCommnad commnad) {
        var asset = await assetRepository.Get(id);
        asset.Edit(commnad.Name, commnad.Code, commnad.Type)
            .WithLocation(commnad.Location)
            .WithInstalledDate(commnad.InstalledAt);

        await assetRepository.Save();
    }

    public async Task Delete(Guid id) {
        await assetRepository.Delete(id);
        await assetRepository.Save();
    }
}
