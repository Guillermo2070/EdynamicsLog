using EdynamicsLog.RepositoryEFCore;
using EdynamicsLog.UseCases;
using EdynamicsLog.Presenters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EdynamicsLog.IoC
{
    public static class DependencyContainerProducts
    {
        public static IServiceCollection AddProductsDependency(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRepositoriesProducts(configuration);
            services.AddUseCasesServicesProducts();
            services.AddPresentersProducts();

            return services;
        }
    }
}
