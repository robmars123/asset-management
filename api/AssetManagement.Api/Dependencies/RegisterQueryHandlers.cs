using AssetManagement.Application.Models.Assets.Queries;
using AssetManagement.Application.Generics;
using MediatR;

namespace AssetManagement.Api.Dependencies
{
    public static class QueryHandlerRegistrar
    {
        public static void RegisterQueryHandler(this IServiceCollection services) {

            services.AddTransient<IRequestHandler<AssetRequestQuery, QueryResult<List<AssetRequestResult>>>, AssetQueryHandler>();
            //services.AddTransient<IConnectionStringResolver, ConnectionStringResolver>();
        }
    }
}
