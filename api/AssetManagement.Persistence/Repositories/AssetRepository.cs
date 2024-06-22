using AssetManagement.Application.Abstractions;
using AssetManagement.Domain.Entities;
using AssetManagement.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Persistence.Repositories
{
    public class AssetRepository : BaseRepository<Asset>, IAssetRepository
    {
        public AssetRepository(AssetManagementDBContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Asset>> GetAssetsAsync() => await _dbContext.Assets.ToListAsync();

        public async Task<Asset> GetByIdAsync(int id) => await _dbContext.Assets.FindAsync(id);
    }
}
