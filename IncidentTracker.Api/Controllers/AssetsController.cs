using IncidentTracker.Application.DTOs.Assets;
using IncidentTracker.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace IncidentTracker.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AssetsController(AssetService assetService) : ControllerBase {

    [HttpPost]
    public async Task<IActionResult> AddAsset(AddAssetCommand command) {
        await assetService.AddAsset(command);
        return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() {
        var result = await assetService.GetAll();
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Edit(Guid id, EditAssetCommnad command) {
        await assetService.Edit(id, command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id) {
        await assetService.Delete(id);
        return NoContent();
    }
}
