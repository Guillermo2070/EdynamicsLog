using EdynamicsLog.RepositoryEFCore;
using EdynamicsLog.UseCases;
using EdynamicsLog.Presenters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EdynamicsLog.IoC
{
    public static class DependencyContainerBussiness
    {
        public static IServiceCollection AddBussinessDependency(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRepositoriesBussiness(configuration);
            services.AddUseCasesServicesBussiness();
            services.AddPresentersBussiness();

            return services;
        }
    }
}
