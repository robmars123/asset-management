
namespace AssetManagement.Api.Client
{
    public interface IAPIClient
    {
        Task<string> GetAssets();
    }
}