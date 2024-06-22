using AssetManagement.Application.Abstractions;
using AssetManagement.Application.MappingProfiles;
using AssetManagement.Application.Models.Assets.Queries;
using AssetManagement.Domain.Entities;
using AutoMapper;
using Moq;
using Xunit;
using Assert = NUnit.Framework.Assert;

namespace AssetManagement.Application.Tests.Assets.Queries
{
    [TestFixture]
    public class AssetQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAssetRepository> mockAssetRepository = new();
        public AssetQueryHandlerTests()
        {
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });

            _mapper = configurationProvider.CreateMapper();

        }
        [Fact]
        public async Task GetAssetsTest()
        {
            //1. ARRANGE
            var expectedCount = 1;
            var handler = new AssetQueryHandler(mockAssetRepository.Object, _mapper);

            //instantiate mock data
            var assets = new List<Asset>
            {
                new Asset
                {
                    Id = 5,
                    Description = "Android Galaxy",
                    EmployeeId = 5
                }
            };

            mockAssetRepository.Setup(r => r.GetAssetsAsync()).ReturnsAsync(assets);

            //2. ACT
            var actual = await handler.Handle(new AssetRequestQuery(), CancellationToken.None);

            //3.// Assert
            Assert.That(actual.Result?.Count(), Is.EqualTo(expectedCount));
        }
    }
}