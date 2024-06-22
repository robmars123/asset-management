using AssetManagement.Application.Abstractions;
using AssetManagement.Application.Generics;
using AutoMapper;
using MediatR;

namespace AssetManagement.Application.Models.Assets.Queries
{
    public class AssetQueryHandler : IRequestHandler<AssetRequestQuery, QueryResult<List<AssetRequestResult>>>
    {
        private readonly IAssetRepository _assetRepository;
        private readonly IMapper _mapper;

        public AssetQueryHandler(IAssetRepository assetRepository, IMapper mapper)
        {
            _assetRepository = assetRepository;
            _mapper = mapper;
        }
        public async Task<QueryResult<List<AssetRequestResult>>> Handle(AssetRequestQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _assetRepository.GetAssetsAsync();
                var assetRequests = _mapper.Map<List<AssetRequestResult>>(result);

                return new QueryResult<List<AssetRequestResult>>(true, assetRequests);
            }
            catch (Exception ex)
            {
                List<string> errorMessages = new List<string> { ex.Message };
                return new QueryResult<List<AssetRequestResult>>(false, errorMessages);
            }
        }
    }
}
