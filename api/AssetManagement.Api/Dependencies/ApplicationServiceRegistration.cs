
using AssetManagement.Application.Models.Assets.Queries;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AssetManagement.Api
{
    public static class ApplicationServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        }
    }
}
