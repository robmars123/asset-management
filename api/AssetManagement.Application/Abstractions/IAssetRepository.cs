using AssetManagement.Domain.Entities;

namespace AssetManagement.Application.Abstractions
{
    public interface IAssetRepository : IAsyncRepository<Asset>
    {
        Task<List<Asset>> GetAssetsAsync();
        Task<Asset> GetByIdAsync(int id);
    }
}
