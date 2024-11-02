using MaintenanceSchedulingApp.Models;
using MaintenanceSchedulingApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace MaintenanceSchedulingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetsController : ControllerBase
    {
        private readonly IRepository<Assets> _assetRepository;
        public AssetsController(IRepository<Assets> assetRepository)
        {
            _assetRepository = assetRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Assets>>> GetAssets()
        {
            var assets = await _assetRepository.GetAllAsync();
            return Ok(assets);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Assets>> GetAsset(int id)
        {
            var asset = await _assetRepository.GetByIdAsync(id);
            if (asset == null)
                return NotFound();
            return Ok(asset);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsset([FromBody] Assets asset)
        {
            await _assetRepository.AddAsync(asset);
            return CreatedAtAction(nameof(GetAsset), new { id = asset.AssetsId }, asset);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsset(int id, [FromBody] Assets updatedAsset)
        {
            if (id != updatedAsset.AssetsId)
                return BadRequest();

            var asset = await _assetRepository.GetByIdAsync(id);
            if (asset == null)
                return NotFound();

            asset.Name = updatedAsset.Name;
            asset.Location = updatedAsset.Location;
            asset.Type = updatedAsset.Type;
            asset.MaintenanceFrequencyInDays = updatedAsset.MaintenanceFrequencyInDays;

            await _assetRepository.UpdateAsync(asset);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsset(int id)
        {
            await _assetRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
}
